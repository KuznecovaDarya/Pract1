//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shop2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Worker
    {
        public long id_worker { get; set; }
        public string Name { get; set; }
        public long id_position { get; set; }
        public string Password { get; set; }
    
        public virtual Position Position { get; set; }
    }
}
