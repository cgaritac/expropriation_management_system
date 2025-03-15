using GestionExpropaciones.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionExpropaciones.Common.Helpers
{
    public static class CantonHelper
    {
        public static IEnumerable<SelectListItem> GetCantonsByProvince(ProvinceEnum province)
        {
            return province switch
            {
                ProvinceEnum.SanJose => Enum.GetValues(typeof(CantonSanJoseEnum))
                    .Cast<CantonSanJoseEnum>()
                    .Select(c => new SelectListItem
                    {
                        Value = ((int)c).ToString(),
                        Text = EnumHelper.GetEnumDescription(c)
                    }),

                ProvinceEnum.Heredia => Enum.GetValues(typeof(CantonHerediaEnum))
                    .Cast<CantonHerediaEnum>()
                    .Select(c => new SelectListItem
                    {
                        Value = ((int)c).ToString(),
                        Text = EnumHelper.GetEnumDescription(c)
                    }),

                ProvinceEnum.Alajuela => Enum.GetValues(typeof(CantonAlajuelaEnum))
                    .Cast<CantonAlajuelaEnum>()
                    .Select(c => new SelectListItem
                    {
                        Value = ((int)c).ToString(),
                        Text = EnumHelper.GetEnumDescription(c)
                    }),

                ProvinceEnum.Cartago => Enum.GetValues(typeof(CantonCartagoEnum))
                    .Cast<CantonCartagoEnum>()
                    .Select(c => new SelectListItem
                    {
                        Value = ((int)c).ToString(),
                        Text = EnumHelper.GetEnumDescription(c)
                    }),

                ProvinceEnum.Guanacaste => Enum.GetValues(typeof(CantonGuanacasteEnum))
                    .Cast<CantonGuanacasteEnum>()
                    .Select(c => new SelectListItem
                    {
                        Value = ((int)c).ToString(),
                        Text = EnumHelper.GetEnumDescription(c)
                    }),

                ProvinceEnum.Limon => Enum.GetValues(typeof(CantonLimonEnum))
                    .Cast<CantonLimonEnum>()
                    .Select(c => new SelectListItem
                    {
                        Value = ((int)c).ToString(),
                        Text = EnumHelper.GetEnumDescription(c)
                    }),

                ProvinceEnum.Puntarenas => Enum.GetValues(typeof(CantonPuntarenasEnum))
                    .Cast<CantonPuntarenasEnum>()
                    .Select(c => new SelectListItem
                    {
                        Value = ((int)c).ToString(),
                        Text = EnumHelper.GetEnumDescription(c)
                    }),

                _ => Enumerable.Empty<SelectListItem>()
            };
        }
    }
}
