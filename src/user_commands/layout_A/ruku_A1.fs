/**Custom Code*/
int UpConveyorNum = Table("UpTable")[1][2];//上箱线数量
int UpConveyorLength = Table("UpTable")[2][2] ;// 上箱线长度
int UpConveyorDistance = Table("UpTable")[3][2];//上箱线间距
int FisrtConveyorLoc = Table("UpTable")[4][2];//上箱线间距

double ConveyorHeight=Table("ConveyorTable")[3][2];

int racknum =Table("RackTable")[1][2];
int AisleNum = Table("RackTable")[8][2];
int TierNum = Table("RackTable")[3][2];
int BayNum = Table("RackTable")[2][2];
int CaseWidth = Table("RackTable")[4][2];

double Length=Table("ConveyorTable")[1][2];
double PickLength=Table("ConveyorTable")[4][2];
double PickWidth=Table("ConveyorTable")[5][2];

double mainLength=3.5*racknum+4;
//double ConveyorHeight=Table("ConveyorTable")[3][2];

//入库上箱线
for(int i=1; i<=UpConveyorNum;i++){
   treenode newConveyor = createinstance(node("conveyor/StraightConveyor", library()), model());
   setsize(newConveyor,UpConveyorLength,1,1);
   setloc(newConveyor,xloc(Model.find("maincoveyor6"))-UpConveyorLength,yloc(Model.find("maincoveyor6"))-mainLength+(i-1)*UpConveyorDistance+FisrtConveyorLoc,ConveyorHeight);
   function_s(newConveyor, "finalizeSpatialChanges");//设置为自动连接
   setname(newConveyor,"UpCoveyor"+numtostring(i));
}


//入库Combiner
for(int i=1; i<=UpConveyorNum;i++){

   treenode libraryCombiner = library().find("?Combiner");
   Object firstCombiner = createinstance(libraryCombiner, model());//创建Combiner
   firstCombiner.name="UpCombiner"+numtostring(i);
   firstCombiner.setSize(3,3,1);
   firstCombiner.location.x = xloc(Model.find("UpCoveyor"+numtostring(i)))-6;
   firstCombiner.location.y = yloc(Model.find("UpCoveyor"+numtostring(i)))+1;
   contextdragconnection(Model.find("UpCombiner"+numtostring(i)),Model.find("UpCoveyor"+numtostring(i)),  "A");
   setrot("UpCombiner"+numtostring(i),0,0,90);

}

//入库source1
for(int i=1; i<=UpConveyorNum;i++){
   treenode librarySource = maintree().find("project/userlibrary/UserLibrary 1/source1");
   Object firstSource = createinstance(librarySource, model());//创建Soure

   setvarnum(firstSource, "itemclass", 7);

   firstSource.name="source1"+numtostring(i);
   firstSource.setSize(1,1,0.5);
   firstSource.location.x = xloc(Model.find("UpCombiner"+numtostring(i)))-3;
   firstSource.location.y = yloc(Model.find("UpCombiner"+numtostring(i)))+1;

int WorkModel=Table("模式选择")[9][2];

   if(WorkModel!=2)
	{
   contextdragconnection(Model.find("source1"+numtostring(i)),Model.find("UpCombiner"+numtostring(i)),  "A");
	}

 //  contextdragconnection(Model.find("source1"+numtostring(i)),Model.find("UpCombiner"+numtostring(i)),  "A");
}


//入库source2
for(int i=1; i<=UpConveyorNum;i++){
   treenode librarySource2 = maintree().find("project/userlibrary/UserLibrary 1/source2");
//   treenode librarySource2 = library().find("?Source");
   Object secondSource = createinstance(librarySource2, model());//创建Soure

   setvarnum(secondSource, "itemclass", 1);

   secondSource.name="source2"+numtostring(i);
   secondSource.setSize(1,1,0.5);
   secondSource.location.x = xloc(Model.find("UpCombiner"+numtostring(i)))-3;
   secondSource.location.y = yloc(Model.find("UpCombiner"+numtostring(i)))-2;

int WorkModel=Table("模式选择")[9][2];

   if(WorkModel!=2)
	{
   contextdragconnection(Model.find("source2"+numtostring(i)),Model.find("UpCombiner"+numtostring(i)),  "A");
	}

//   contextdragconnection(Model.find("source2"+numtostring(i)),Model.find("UpCombiner"+numtostring(i)),  "A");
}
