
namespace Obligatorio.Domain
{
    public class OfferFilter
    {
        public int UserCi { get; set; }
        public EnumRoles.RolOferta UsersRole { get; set; }
        public EnumOfertas.EstadoOferta OfferState { get; set; }
    }
}
