using TemplateAudacesApi.Models;

namespace TemplateAudacesApi.Utils
{
    public class ObjectoGenerico
    {
        public string? name { get; set; }
        public string? code { get; set; }
        public string? reference { get; set; }
        public double? quantity { get; set; }
    }
    public class UtilConverter
    {
        public static void AudacesTo(ObjectoGenerico prod, Material material)
        {
            prod.code = material.uid;
            prod.name = material.name;
            prod.quantity = material.value;
            prod.reference = material.reference;
        }

        public static void AudacesTo(ObjectoGenerico prod, Garment garment)
        {
            prod.code = garment.uid;
            prod.name = garment.name;
            prod.quantity = garment.value;
            prod.reference = garment.reference;
        }

        public static void ToAudaces(ObjectoGenerico prod, Material material)
        {
            material.uid = prod.code;
            material.name = prod.name;
            material.value = prod.quantity;
            material.reference = prod.reference;
        }

        public static void ToAudaces(ObjectoGenerico prod, Garment garment)
        {
            garment.uid = prod.code;
            garment.name = prod.name;
            garment.value = prod.quantity;
            garment.reference = prod.reference;
        }
    }
}
