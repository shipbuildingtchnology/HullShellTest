﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HullShellTest.ModelData;

namespace HullShellTest.DAL
{
    public class StdHullShellDAL
    {
        //增加
        public static int AddStdHullShell(StdHullShellCls StdShell)
        {
            using (HullShellContainer hs = new HullShellContainer())
            {
                //包围盒
                BoundingBox boundbox = new BoundingBox
                {
                    x_Dir = StdShell.Dir.x,
                    y_Dir = StdShell.Dir.y,
                    z_Dir = StdShell.Dir.z,

                    x_Min = StdShell.Pt_Min.x,
                    y_Min = StdShell.Pt_Min.y,
                    z_Min = StdShell.Pt_Min.z,

                    x_Max = StdShell.Pt_Max.x,
                    y_Max = StdShell.Pt_Max.y,
                    z_Max = StdShell.Pt_Max.z,

                };


                //理论点
                TheoryPoints tps = new TheoryPoints 
                {
                    RowNumber = StdShell.tpc.RowNumberow,
                    ColumnNumber=StdShell.tpc.ColnumNumber
                };

                for (int i = 0; i < StdShell.tpc.PointsCloudList.Count; i++)
                {
                    Point pt = new Point
                    {
                        X = StdShell.tpc.PointsCloudList[i].x,
                        Y = StdShell.tpc.PointsCloudList[i].y,
                        Z = StdShell.tpc.PointsCloudList[i].z,
                    };

                    tps.Point.Add(pt);
                }

                
                //增加肋位线点
                RiblinePoints rps = new RiblinePoints();

                for (int i=0;i<StdShell.tpc.RiblinePointsList.Count;i++)
                {
                    Point pt = new Point
                    {
                        X = StdShell.tpc.RiblinePointsList[i].x,
                        Y = StdShell.tpc.RiblinePointsList[i].y,
                        Z = StdShell.tpc.RiblinePointsList[i].z,
                    };

                    rps.Point.Add(pt);

                }

                //增加边缘点
                EdgeEdgePoints eeps = new EdgeEdgePoints();
                for (int i = 0; i < StdShell.tpc.EdgeEdgePointsList.Count; i++)
                {
                    Point pt = new Point
                    {
                        X = StdShell.tpc.EdgeEdgePointsList[i].x,
                        Y = StdShell.tpc.EdgeEdgePointsList[i].y,
                        Z = StdShell.tpc.EdgeEdgePointsList[i].z,
                    };

                    eeps.Point.Add(pt);

                }

                //增加余量点
                ExcessPoints expts = new ExcessPoints();
                for (int i = 0; i < StdShell.tpc.ExcessPointsList.Count; i++)
                {
                    Point pt = new Point
                    {
                        X = StdShell.tpc.ExcessPointsList[i].x,
                        Y = StdShell.tpc.ExcessPointsList[i].y,
                        Z = StdShell.tpc.ExcessPointsList[i].z,
                    };

                    expts.Point.Add(pt);

                }

                //添加
                StdHullShell shs = new StdHullShell
                {
                    PlateModel = StdShell.PlateModel,
                    Thickness = StdShell.Thickness,
                    Width1 = StdShell.Width1,
                    Length1 = StdShell.Length1,
                    TransverseCurvate = StdShell.TransverseCurvate,
                    RiblineAmount = StdShell.RiblineCount,
                    LongitudinalCurvature = StdShell.LongitudinalCurvature,
                    CurvePlateKind = StdShell.CurvePlateKind,
                    Width2 = StdShell.Width2,
                    Length2 = StdShell.Length2,
                    ShipName = StdShell.ShipName,

                    TheoryPoints=tps,
                    RiblinePoints=rps,
                    EdgeEdgePoints=eeps,
                    ExcessPoints=expts,
                    BoundingBox=boundbox

                };


                hs.AddToStdHullShellSet(shs);

                return hs.SaveChanges();

            }
        }

        //删除 Name
        public static int DeleteStdHullShellByName(string _name)
        {
            using (HullShellContainer hs = new HullShellContainer())
            {
                StdHullShell shs = hs.StdHullShellSet.Where(s => s.PlateModel == _name).FirstOrDefault();

                //删除包围盒
                BoundingBox boundbox = shs.BoundingBox;
                hs.DeleteObject(boundbox);

                //删除理论点
                TheoryPoints tps = shs.TheoryPoints;
                List<Point> tpsList = tps.Point.ToList();
                for (int i = 0; i < tpsList.Count; i++)
                {
                    hs.DeleteObject(tpsList[i]);
                }
                hs.DeleteObject(tps);

                //删除肋位线点
                RiblinePoints rps = shs.RiblinePoints;
                List<Point> rpList = rps.Point.ToList();
                for (int i = 0; i < rpList.Count; i++)
                {
                    hs.DeleteObject(rpList[i]);
                }
                hs.DeleteObject(rps);

                //删除余量点
                ExcessPoints eeps = shs.ExcessPoints;
                List<Point> eepList = eeps.Point.ToList();
                for (int i = 0; i < eepList.Count; i++)
                {
                    hs.DeleteObject(eepList[i]);
                }
                hs.DeleteObject(eeps);

                //删除边角点
                EdgeEdgePoints exps = shs.EdgeEdgePoints;
                List<Point> expList = exps.Point.ToList();
                for (int i = 0; i < expList.Count; i++)
                {
                    hs.DeleteObject(expList[i]);
                }
                hs.DeleteObject(exps);

                hs.DeleteObject(shs);

                return hs.SaveChanges();

            }
        }

        //删除，Id
        public static int DeleteStdHullShellByName(int Id)
        {
            using (HullShellContainer hs = new HullShellContainer())
            {
                StdHullShell shs = hs.StdHullShellSet.Where(s => s.PlateModel == _name).FirstOrDefault();

                //删除包围盒
                BoundingBox boundbox = shs.BoundingBox;
                hs.DeleteObject(boundbox);

                //删除理论点
                TheoryPoints tps = shs.TheoryPoints;
                List<Point> tpsList = tps.Point.ToList();
                for (int i = 0; i < tpsList.Count; i++)
                {
                    hs.DeleteObject(tpsList[i]);
                }
                hs.DeleteObject(tps);

                //删除肋位线点
                RiblinePoints rps = shs.RiblinePoints;
                List<Point> rpList = rps.Point.ToList();
                for (int i = 0; i < rpList.Count; i++)
                {
                    hs.DeleteObject(rpList[i]);
                }
                hs.DeleteObject(rps);

                //删除余量点
                ExcessPoints eeps = shs.ExcessPoints;
                List<Point> eepList = eeps.Point.ToList();
                for (int i = 0; i < eepList.Count; i++)
                {
                    hs.DeleteObject(eepList[i]);
                }
                hs.DeleteObject(eeps);

                //删除边角点
                EdgeEdgePoints exps = shs.EdgeEdgePoints;
                List<Point> expList = exps.Point.ToList();
                for (int i = 0; i < expList.Count; i++)
                {
                    hs.DeleteObject(expList[i]);
                }
                hs.DeleteObject(exps);

                hs.DeleteObject(shs);

                return hs.SaveChanges();

            }
        }


        //修改,基本信息
        public int ModifyStdHullShell(StdHullShellCls StdShell)
        {
            using (HullShellContainer hs = new HullShellContainer())
            {
                StdHullShell shs = hs.StdHullShellSet.Where(s => s.PlateModel == StdShell.PlateModel).FirstOrDefault();

                shs.PlateModel = StdShell.PlateModel;
                shs.Thickness = StdShell.Thickness;
                shs.Width1 = StdShell.Width1;
                shs.Length1 = StdShell.Length1;
                shs.TransverseCurvate = StdShell.TransverseCurvate;
                shs.RiblineAmount = StdShell.RiblineCount;
                shs.LongitudinalCurvature = StdShell.LongitudinalCurvature;
                shs.CurvePlateKind = StdShell.CurvePlateKind;
                shs.Width2 = StdShell.Width2;
                shs.Length2 = StdShell.Length2;
                shs.ShipName = StdShell.ShipName;

                shs.BoundingBox.x_Dir = StdShell.Dir.x;
                shs.BoundingBox.y_Dir = StdShell.Dir.y;
                shs.BoundingBox.z_Dir = StdShell.Dir.z;

                shs.BoundingBox.x_Min = StdShell.Pt_Min.x;
                shs.BoundingBox.y_Min = StdShell.Pt_Min.y;
                shs.BoundingBox.z_Min = StdShell.Pt_Min.z;

                shs.BoundingBox.x_Max = StdShell.Pt_Max.x;
                shs.BoundingBox.y_Max = StdShell.Pt_Max.y;
                shs.BoundingBox.z_Max = StdShell.Pt_Max.z;

                return hs.SaveChanges();

            }

        }

        //查询
        public StdHullShellCls QueryStdHullShell(string _name)
        {
            using (HullShellContainer hs = new HullShellContainer())
            {
                StdHullShellCls shscls = new StdHullShellCls();
                StdHullShell shs = hs.StdHullShellSet.Where(s => s.PlateModel == _name).FirstOrDefault();

                shscls.PlateModel = shs.PlateModel;
                shscls.Thickness = shs.Thickness;
                shscls.Width1 = shs.Width1;
                shscls.Length1 = shs.Length1;
                shscls.TransverseCurvate = shs.TransverseCurvate;
                shscls.RiblineCount = shs.RiblineAmount;
                shscls.LongitudinalCurvature = shs.LongitudinalCurvature;
                shscls.CurvePlateKind = shs.CurvePlateKind;
                shscls.Width2 = shs.Width2;
                shscls.Length2 = shs.Length2;
                shscls.ShipName = shs.ShipName;

                List<Point> tpsList = shs.TheoryPoints.Point.ToList();
                for (int i = 0; i < tpsList.Count;i++ )
                {
                    shscls.tpc.PointsCloudList.Add(new PointCls { x = tpsList[i].X, y = tpsList[i].Y, z = tpsList[i].Z });
                }

                List<Point> rpsList = shs.RiblinePoints.Point.ToList();
                for (int i = 0; i < rpsList.Count; i++)
                {
                    shscls.tpc.RiblinePointsList.Add(new PointCls { x = tpsList[i].X, y = tpsList[i].Y, z = tpsList[i].Z });
                }

                List<Point> eepList = shs.EdgeEdgePoints.Point.ToList();
                for (int i = 0; i < eepList.Count; i++)
                {
                    shscls.tpc.EdgeEdgePointsList.Add(new PointCls { x = tpsList[i].X, y = tpsList[i].Y, z = tpsList[i].Z });
                }

                List<Point> expList = shs.ExcessPoints.Point.ToList();
                for (int i = 0; i < expList.Count; i++)
                {
                    shscls.tpc.ExcessPointsList.Add(new PointCls { x = tpsList[i].X, y = tpsList[i].Y, z = tpsList[i].Z });
                }

                shscls.Dir.x = shs.BoundingBox.x_Dir;
                shscls.Dir.y = shs.BoundingBox.y_Dir;
                shscls.Dir.z = shs.BoundingBox.z_Dir;

                shscls.Pt_Min.x = shs.BoundingBox.x_Min;
                shscls.Pt_Min.y = shs.BoundingBox.y_Min;
                shscls.Pt_Min.z = shs.BoundingBox.z_Min;

                shscls.Pt_Max.x = shs.BoundingBox.y_Max;
                shscls.Pt_Max.y = shs.BoundingBox.y_Max;
                shscls.Pt_Max.z = shs.BoundingBox.z_Max;

                return shscls;

            }
        }

        //清空
        public int ClearProcessEquipment()
        {

            using (HullShellContainer hs = new HullShellContainer())
            {
                int re = 0;

                List<StdHullShell> shsList = hs.StdHullShellSet.Where(p => p.Id >= 0).ToList();
                //StdHullShell shs = hs.StdHullShellSet.Where(s => s.PlateModel == _name).FirstOrDefault();

                for (int i = 0; i < shsList.Count; i++)
                {
                    re=DeleteStdHullShell(shsList[i].PlateModel);
                }

                return re;


            }

        }

    }
}
