using BusReservations.Core.Domain;
using IronPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core
{
    public sealed class TicketUtilities
    {
        private static TicketUtilities? _instance = null;
        private static readonly string _assetsPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "BusReservations.Core\\ticket_assets");

        public static TicketUtilities Instance => _instance ?? (_instance = new TicketUtilities());
        private TicketUtilities() { }

        public PdfDocument ConvertToPdf(Reservation ticket)
        {

            var html = FormatTicketData(ticket);
            var renderer = new ChromePdfRenderer();
            renderer.RenderingOptions.CustomCssUrl = "https://fonts.googleapis.com/icon?family=Material+Icons";
            renderer.RenderingOptions.MarginBottom = 0;
            renderer.RenderingOptions.MarginLeft = 0;
            renderer.RenderingOptions.MarginRight = 0;
            renderer.RenderingOptions.MarginTop = 0;
            renderer.RenderingOptions.FitToPaperMode = IronPdf.Engines.Chrome.FitToPaperModes.FixedPixelWidth;
            return renderer.RenderHtmlAsPdf(html, _assetsPath);
        }
        private string FormatTicketData(Reservation ticket)
        {

            return @$"    <link
      rel=""stylesheet""
      href=""styles.css""
    />
    <link
      href=""https://fonts.googleapis.com/icon?family=Material+Icons""
      rel=""stylesheet""
    /> <span class=""title"">Bilet de calatorie</span>
    <span class=""subtitle"">Cursa:</span>
    <div
      class=""details""
      style=""margin-bottom: 30px""
    >
      <div>
        <span class=""date"">{ticket.BusDrivenRoute.DrivenRoute.TimeTable.DepartureDate.ToString("dd.MM.yyyy, HH:mm")}</span>
        <span>De la : {ticket.BusDrivenRoute.DrivenRoute.Start}</span>
        <span class=""material-icons"">arrow_downward</span>
        <span class=""date"">{ticket.BusDrivenRoute.DrivenRoute.TimeTable.ArivvalDate.ToString("dd.MM.yyyy, HH:mm")}</span>
        <span>La : {ticket.BusDrivenRoute.DrivenRoute.Destination}</span>
      </div>
      <div><span class=""material-icons"">arrow_forward</span></div>

      <div>
        <span>Autobuz</span>
        <span><span class=""material-icons"">directions_bus</span></span>
        <span>{ticket.BusDrivenRoute.Bus.Name}</span>
      </div>
      <div><span class=""material-icons"">arrow_forward</span></div>

      <div>
        <span>Pret bilet</span>
        <span><span class=""material-icons"">payment</span></span>
        <span>{ticket.FinalSeatPrice} lei</span>
      </div>
    </div>
    <span class=""subtitle"">Detalii loc:</span>
    <div class=""details"">
      <span>Numar loc: {ticket.Seat.SeatNumber}</span>
      <span>Tip bilet: {ticket.Seat.Type}</span>
    </div>
    <span class=""subtitle"">Detalii client:</span>
    <div class=""details user"">
      <div>Nume: <span class=""important"">{ticket.User.FullName}</span></div>
      <div>
        Numar de telefon:
        <span class=""important"">{ticket.User.PhoneNumber}</span>
      </div>
      <div>
        Adresa de e-mail:
        <span class=""important"">{ticket.User.Email}</span>
      </div>
    </div>";
        }
    }
}
