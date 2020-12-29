using static System.Environment;
using XRL.Wish;
using XRL.World;

public static class helado_ZoneMapper_WishHandler
{
    public const string WISH_NAME = "mapzone";

    [WishCommand(Command = WISH_NAME)]
    public static bool HandleWish()
    {
        var activeZone = ZoneManager.instance.ActiveZone;

        var filePath = XRL.DataManager.SavePath(
            $"{activeZone.ZoneID}-Exported.rpm"
        );

        var xmlWriter = System.Xml.XmlWriter.Create(filePath);

        // <Map Width="80" Height="25">
        xmlWriter.WriteStartElement("Map");
        xmlWriter.WriteAttributeString("Width", "80");
        xmlWriter.WriteAttributeString("Height", "25");

        foreach (var cell in activeZone.GetCells())
        {
            // <cell X="?" Y="?">
            xmlWriter.WriteStartElement("cell");
            xmlWriter.WriteAttributeString("X", cell.X.ToString());
            xmlWriter.WriteAttributeString("Y", cell.Y.ToString());

            foreach (var gameObject in cell.GetObjects())
            {
                if (!(gameObject.IsPlayer() || gameObject.IsPlayerLed()))
                {
                    // <object Name="?" Owner="?" />

                    xmlWriter.WriteStartElement("object");

                    xmlWriter.WriteAttributeString("Name",
                        gameObject.Blueprint);

                    if (gameObject.Owner != null)
                    {
                        xmlWriter.WriteAttributeString("Owner",
                            gameObject.Owner);
                    }

                    xmlWriter.WriteEndElement();
                }
            }

            // </cell>
            xmlWriter.WriteEndElement();
        }

        // </Map>
        xmlWriter.WriteEndElement();

        xmlWriter.Close();
        XRL.UI.Popup.Show($"All done! You can find your map at {filePath}!");
        return true;
    }
}
