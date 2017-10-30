using System.Collections.Generic;
using CPMobile.Helper;

namespace CPMobile.Models
{
    public enum AuthorDataType
    {
        Article,
        Message,
        Tips,
        TechBlog,
        Comments,
        Categoria
    }


    public class CPFeed
    {
        public Pagination pagination { get; set; }
        public List<Item> items { get; set; }
    }

    public class CPFeedCat
    {
        public List<Categoria> Categos { get; set; }
    }

    public class Pagination
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalItems { get; set; }
    }

    public class Author
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class DocType
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Categoria
    {
        public string desCategoria { get; set; }
        public string activo { get; set; }
        public int cveCategoria { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class License
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class ThreadEditor
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Item
    {
        public string idNoticia { get; set; }
        public string contenido { get; set; }
        public string titulo { get; set; }

        //private string _resumen = string.Empty;
        //public string resumen
        //{
        //    get
        //    {
        //        return  resumen;
        //    }
        //    set
        //    {
        //        if (contenido != "")
        //        {
        //            resumen = contenido.ToString().Truncate(150);
        //        }else{
        //            resumen = "";
        //        }
        //    }
        //}
        public string autor { get; set; }
        public string cveCategoria { get; set; }
        public string url_imagen { get; set; }
       


        public double rating { get; set; }
        public int votes { get; set; }
        public double popularity { get; set; }
        public string websiteLink { get; set; }
        public string apiLink { get; set; }
        public int parentId { get; set; }
        public int threadId { get; set; }
        public int indentLevel { get; set; }
    }

}
