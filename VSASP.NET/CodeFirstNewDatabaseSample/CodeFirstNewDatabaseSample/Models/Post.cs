using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample.Models
{
    public class Post
    {
        public int PostId { get; set; }
        //标题
        public string Title { get; set; }
        //内容
        public string Content { get; set; }
        //这是博客的数据
           //他的关联的ID
        public int BlogId { get; set; }
          //他的博客的所有数据
        public virtual Blog Blog { get; set; }
    }
}
