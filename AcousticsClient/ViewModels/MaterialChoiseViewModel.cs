using AcousticsClient.Models;
using AcousticsClient.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcousticsClient.ViewModels
{
    internal class MaterialChoiseViewModel:ViewModel
    {
        public List<Surface> Surfaces=new List<Surface>();

        public MaterialChoiseViewModel()
        {
            Surfaces.Add(new Surface("Бетон", 0.97));
            Surfaces.Add(new Surface("Гипс", 0.98));
            Surfaces.Add(new Surface("Дерево", 0.85));
            Surfaces.Add(new Surface("Кирпич", 0.55));
            Surfaces.Add(new Surface("Стекло", 0.8));
            Surfaces.Add(new Surface("Пластик", 0.96));
            Surfaces.Add(new Surface("Ковер", 0.23));
        }
    }
}
