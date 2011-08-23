using System.Data;
using System.Globalization;
using System.Reflection;
using Drikka.Geo.Data.Contracts.Binders;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.Binders
{
    /// <summary>
    /// Bind the domain object
    /// </summary>
    public class ObjectBinder : IBinder
    {
        #region Fields

        /// <summary>
        /// Mappings
        /// </summary>
        private readonly IMapping _mapping;

        /// <summary>
        /// Types Register
        /// </summary>
        private readonly ITypeRegister _typesRegister;

        /// <summary>
        /// Infos
        /// </summary>
        private Info[] _infos;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapping">Mappings</param>
        /// <param name="typeRegister">Types Register</param>
        public ObjectBinder(IMapping mapping, ITypeRegister typeRegister)
        {
            this._mapping = mapping;
            this._typesRegister = typeRegister;
        }

        #endregion

        /// <summary>
        /// Bind the object with record data
        /// </summary>
        /// <param name="record">Record</param>
        /// <param name="domain">Domain object</param>
        public void Bind(IDataRecord record, object domain)
        {
            var array = this._infos ?? CreateCache(record);

            for (int i = 0; i < record.FieldCount; i++)
            {
                var info = array[i];
                info.Attribute.PropertyInfo.SetValue(domain, info.TypeMapping.Converter.Read(record.GetValue(i)),
                                                     BindingFlags.SetProperty, null, null,
                                                     CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Create a cache os infos
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Cache</returns>
        private Info[] CreateCache(IDataRecord record)
        {
            var array = new Info[record.FieldCount];
            //var mappings = this._mapping.AllMapping;

            for (int i = 0; i < record.FieldCount; i++)
            {
                var att = this._mapping.GetByFieldName(record.GetName(i));
                var map = this._typesRegister.Get(att.PropertyInfo.PropertyType);
                array[i] = new Info() { Attribute =  att, TypeMapping = map};
            }

            this._infos = array;

            return array;
        }
    }

    /// <summary>
    /// Info structure
    /// </summary>
    internal struct Info
    {
        /// <summary>
        /// Attributes
        /// </summary>
        public IAttribute Attribute { get; set; }

        /// <summary>
        /// Type maped
        /// </summary>
        public ITypeMapping TypeMapping { get; set;}
    }
}
