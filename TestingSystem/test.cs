//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestingSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class test
    {
        public test()
        {
            this.user_test = new HashSet<user_test>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string ftp_path { get; set; }
    
        public virtual ICollection<user_test> user_test { get; set; }
    }
}
