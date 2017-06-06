using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optional;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace SpecialApp.Base
{
    public static class GenericExtension
    {
        public static bool HasNoValue<T>(this T value) => value == null;

        /// <summary>
        /// Converts object to sql param and if it is null then add dbnull value
        /// </summary>
        /// <param name = "value" > Object value</param>
        /// <param name = "name" > Name of sql parameter</param>
        /// <returns></returns>
        public static SqlParameter ToSqlParam(this object value, string name)
        {
            SqlParameter result = new SqlParameter()
            {
                ParameterName = name
            };
            if (value == null)
                result.Value = DBNull.Value;
            else
                result.Value = value;
            return result;
        }

        public static bool IsNull<T>(this T value) => ReferenceEquals(null, value);

        public static bool IsNullOrDefault<T>(this T value)
        {
            var result = IsNull(value);
            if (result == false)
            {
                result = Equals(value, default(T));
            }
            return result;
        }

        public static bool IsNotNullOrDefault<T>(this T value) => !IsNullOrDefault(value);


        public static PropertyBuilder<T> IsOptional<T>(this PropertyBuilder<T> value)
        {
            value.IsRequired(required: false);
            return value;
        }

        /// <summary>
        /// This is just to avoid the generated <b>HasColumnType</b>, via entity framework tool, which is not required in ef core
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyBuilder<T> HasColumnTypeOverride<T>(this PropertyBuilder<T> value, string name) => value;

        public static byte[] ToByteArray(this Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }

        public static T NoneWhenNullOrDefault<T>(this T Value, Func<T> valueOr)
        {
            return Value.NoneWhen((x) => x.IsNullOrDefault()).ValueOr(valueOr);
        }
    }
}
