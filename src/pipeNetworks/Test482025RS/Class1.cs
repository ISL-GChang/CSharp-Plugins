using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.DatabaseServices;
using System;


[assembly: CommandClass(typeof(C3D2024PluginDemo.RenamePipes))]

namespace C3D2024PluginDemo
{
    public class RenamePipes
    {
        [CommandMethod("RENAMEPIPES")]
        public void RenameSelectedPipeNetwork()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var ed = doc.Editor;
            var db = doc.Database;
            var civDoc = CivilApplication.ActiveDocument;

            // 1. Prompt user to select any Pipe or Structure
            PromptEntityOptions peo = new PromptEntityOptions("\nSelect a pipe or structure in the network:");
            peo.SetRejectMessage("\nMust select a pipe or structure.");
            peo.AddAllowedClass(typeof(Pipe), true);
            peo.AddAllowedClass(typeof(Structure), true);

            PromptEntityResult per = ed.GetEntity(peo);
            if (per.Status != PromptStatus.OK)
                return;

            ObjectId netId = per.ObjectId;
            ed.WriteMessage($"\nSelected Pipe Network id: {netId}");


            using (doc.LockDocument())
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                Autodesk.AutoCAD.DatabaseServices.Entity ent = tr.GetObject(per.ObjectId, OpenMode.ForRead) as Autodesk.AutoCAD.DatabaseServices.Entity;
                Pipe selected_pipe = ent as Pipe;
                Structure structure = ent as Structure;

                ObjectId networkId = ObjectId.Null;

                // 3. Find parent PipeNetwork
                if (selected_pipe != null)
                    networkId = selected_pipe.NetworkId;
                else if (structure != null)
                    networkId = structure.NetworkId;

                if (networkId == ObjectId.Null)
                {
                    ed.WriteMessage("\nSelected object is not part of a network.");
                    return;
                }

                // 4. Get the PipeNetwork object
                Network network = tr.GetObject(networkId, OpenMode.ForRead) as Network;
                ed.WriteMessage($"\nSelected network name: {network.Name}");
                foreach (ObjectId pipeId in network.GetPipeIds())
                {
                    var pipe = tr.GetObject(pipeId, OpenMode.ForWrite) as Pipe;

                    string upName = "None", downName = "None";
                    if (pipe.StartStructureId != ObjectId.Null)
                        upName = (tr.GetObject(pipe.StartStructureId, OpenMode.ForRead) as Structure)?.Name ?? "None";
                    if (pipe.EndStructureId != ObjectId.Null)
                        downName = (tr.GetObject(pipe.EndStructureId, OpenMode.ForRead) as Structure)?.Name ?? "None";

                    pipe.Name = $"{upName}_{downName}";
                    ed.WriteMessage($"\nNew pipe name: {pipe.Name}");

                }


                tr.Commit();
            }
            ed.WriteMessage("\nAll pipes renamed successfully.");
        }
    }
}
