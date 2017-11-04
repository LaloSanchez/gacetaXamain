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

    public class Galery
    {
        public int idGaleria { set; get; }
        private string _url_imagen = string.Empty;
        public string url_imagen
        {
            get
            {
                return _url_imagen;
            }
            set
            {
                _url_imagen = "http://189.211.201.181:75/" + value.ToString();
            }
        }
        public string titulo { set; get; }
        public string descripcion { set; get; }
        public string activo { set; get; }
    }
    public class CPFeedGalery
    {
        public List<Galery> itemsGalery { get; set; }
    }

    public class CPFeedGacetasPdf
    {
        public List<GacetaPdf> itemsGacetasPdf { get; set; }
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

    public class GacetaPdf
    {
        public int idGacetaPdf { get; set; }
        public string titulo { get; set; }

        private string _url_pdf = string.Empty;
        public string url_pdf
        {
            get
            {
                return _url_pdf;
            }
            set
            {
                _url_pdf = "http://189.211.201.181:75/" + value.ToString();
            }
        }
        public string activo { get; set; }
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
        public string contenido { 
            get
            {
                return _contenido;
            }
            set
            {
                _contenido =  value.ToString();
            }
        }
        public string titulo { get; set; }
        public string _contenido;
        public string resumen {
            get
            {
                return contenido.ToString().Truncate(150)+"...";
            }
            set
            {
                _contenido = value;
            }
        }

        private string _url_imagen = string.Empty;
        public string url_imagen
        {
            get
            {
                return  _url_imagen;
            }
            set
            {
                _url_imagen = "http://189.211.201.181:75/" +value.ToString();
            }
        }

        public string autor { get; set; }
        public string cveCategoria { get; set; }
        //public string url_imagen { get; set{return "http://189.211.201.181:75/" +url_imagen} }
       


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
