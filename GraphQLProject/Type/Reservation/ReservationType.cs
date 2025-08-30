using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type.Reservation;

public class ReservationType : ObjectGraphType<ReservationModel>
{
    public ReservationType()
    {
        Field(x => x.Id).Description("Unique identifier for the reservation.");
        Field(x => x.CustomerName).Description("Name of the customer making the reservation.");
        Field(x => x.Email).Description("Email address of the customer.");
        Field(x => x.PhoneNumber).Description("Phone number of the customer.");
        Field(x => x.PartySize).Description("Number of people included in the reservation.");
        Field(x => x.SpecialRequest, nullable: true).Description("Any special request made by the customer.");
        Field(x => x.ReservationDate).Description("Date and time of the reservation.");
    }
}
