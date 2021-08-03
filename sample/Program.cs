using System;
using netDxf;
using netDxf.Blocks;
using netDxf.Collections;
using netDxf.Entities;
using netDxf.Header;
using netDxf.Objects;
using netDxf.Tables;
using netDxf.Units;

namespace sample
{
    class Program
    {
        public static void Main()
        {
            // your DXF file name
            string file = "sample.dxf";

            // create a new document, by default it will create an AutoCad2000 DXF version
            DxfDocument doc = new DxfDocument();
            // an entity
            Line entity = new Line(new Vector2(5, 5), new Vector2(10, 5));
            // add your entities here
            doc.Entities.Add(entity);
            
            var text1 = new Text("Sample text", new Vector2(50,20), 0.1);
            text1.Rotation = 30;
            text1.Alignment = TextAlignment.MiddleCenter;
            // add your entities here
            doc.Entities.Add(text1);
            // save to file
            doc.Save(file);

            // this check is optional but recommended before loading a DXF file
            DxfVersion dxfVersion = DxfDocument.CheckDxfFileVersion(file);
            // netDxf is only compatible with AutoCad2000 and higher DXF versions
            if (dxfVersion < DxfVersion.AutoCad2000) return;
            // load file
            DxfDocument loaded = DxfDocument.Load(file);
        }
    }
}
