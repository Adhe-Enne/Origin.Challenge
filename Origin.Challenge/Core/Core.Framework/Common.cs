using System;

namespace Core.Framework
{
    public static class Common
    {
        public static string setOperationNumber()
        {
            return setOperationNumber(12);
        }

        public static string setOperationNumber(int length)
        {
            return new Random(Environment.TickCount).NextDouble().ToString("0.000000000000").Substring(2, length);
        }
        
        public static bool IsMaxThan(DateTime date, DateTime toValid)
        {
            int result = DateTime.Compare(date, toValid);

            if (result < 0)
                return true;

            return false;
        }
        
        public static bool IsInteger(object data)
        {
            return (ToInteger(data) != int.MinValue);
        }
        public static int ToInteger(object data)
        {
            int aux = int.MinValue;

            if (data != null && data.GetType() == typeof(byte[]))
            {
                string str = string.Empty;
                byte[] l = (byte[])data;
                foreach (byte b in l)
                    str += (char)b;

                if (int.TryParse(str, out aux))
                    return aux;
                else
                    return int.MinValue;
            }
            else if (data != null && data.ToString() != string.Empty)
            {
                if (int.TryParse(data.ToString().Trim(), out aux))
                    return aux;
                else
                    return int.MinValue;
            }

            return aux;
        }
        public static int ToInteger(object data, int def)
        {
            int aux = ToInteger(data);
            if (aux == int.MinValue)
                return def;
            else
                return aux;
        }

        public static Int16 ToInteger16(object data)
        {
            Int16 aux = Int16.MinValue;

            if (data != null && data.GetType() == typeof(byte[]))
            {
                string str = string.Empty;
                byte[] l = (byte[])data;
                foreach (byte b in l)
                    str += (char)b;

                if (Int16.TryParse(str, out aux))
                    return aux;
                else
                    return Int16.MinValue;
            }
            else if (data != null && data.ToString() != string.Empty)
            {
                if (Int16.TryParse(data.ToString().Trim(), out aux))
                    return aux;
                else
                    return Int16.MinValue;
            }

            return aux;
        }
       
        public static string ToString(object data)
        {
            if (data == null)
                return string.Empty;
            else if (data is DateTime)
                return ((DateTime)data).ToString("dd/MM/yyyy");
            else if (data is decimal)
                return string.Format("{0:0.00}", data);

            return data.ToString().Trim();
        }
    
    }
}
