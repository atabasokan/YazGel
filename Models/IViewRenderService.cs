using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace YazGel.Models
{
    public interface IViewRenderService
    {
        Task<String> RenderToStringAsync(string viewName, object model);
    }
}
