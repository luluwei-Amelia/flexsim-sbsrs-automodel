int RowNum =Table("RackTable")[1][2];
int AisleNum = Table("RackTable")[8][2];
int TierNum = Table("RackTable")[3][2];

double CaseLength = Table("RackTable")[5][2];
double CaseWidth = Table("RackTable")[4][2];
double CaseHeight = Table("RackTable")[6][2];

int LayerTier = CaseHeight*Table("RackTable")[14][2];

double EleLength = Table("ElevatorTable")[1][2];
double EleWidth = Table("ElevatorTable")[2][2];
double EleHeight = Table("ElevatorTable")[3][2];


double AisleConveyorLength=Table("ConveyorTable")[1][2];
double ConveyorWidth=Table("ConveyorTable")[10][2];
double ConveyorHeight=Table("ConveyorTable")[3][2];
double ConveyorSpeed=Table("ConveyorTable")[16][2];

double MainConveyorExtend=Table("ConveyorTable")[11][2];
double CircleConveyorWidth=Table("ConveyorTable")[12][2];

int PutConveyorNum=Table("UpTable")[1][2];
double PutConveyorInterval=Table("UpTable")[3][2];
double PutConveyorLength=Table("UpTable")[2][2];
double FirstPutConveyorLocation=Table("UpTable")[4][2];

int SortConveyorNum=Table("ConveyorTable")[6][2];
double SortConveyorInterval=Table("ConveyorTable")[7][2];
double SortConveyorSize1=Table("ConveyorTable")[5][2];
double SortConveyorSize2=Table("ConveyorTable")[4][2];

double FirstSortConveyorLocation=Table("ConveyorTable")[13][2];
double LOutConveyorLength=Table("ConveyorTable")[14][2];
double LInConveyorLength=Table("ConveyorTable")[15][2];


//上箱线
for(int i=1;i<=PutConveyorNum;i++)
{
	treenode newConveyor7 = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor7,PutConveyorLength,1,1);
	setloc(newConveyor7,xloc(Model.find("Inmainconveyor3"))-FirstPutConveyorLocation-(PutConveyorInterval)*(i-1),yloc(Model.find("Inmainconveyor3"))+PutConveyorLength,ConveyorHeight);
	setrot(newConveyor7,0,0,270);
	function_s(newConveyor7, "finalizeSpatialChanges");//设置为自动连接
	setname(newConveyor7,"UpCoveyor"+numtostring(i));

}

//入库Combiner
for(int i=1; i<=PutConveyorNum;i++){

   treenode libraryCombiner = library().find("?Combiner");
   Object firstCombiner = createinstance(libraryCombiner, model());//创建Combiner
   firstCombiner.name="UpCombiner"+numtostring(i);
   firstCombiner.setSize(3,3,1);
   setrot(firstCombiner,0,0,270);

   firstCombiner.location.x = xloc(Model.find("UpCoveyor"+numtostring(i)))+1;
   firstCombiner.location.y = yloc(Model.find("UpCoveyor"+numtostring(i)))+3;
   contextdragconnection(Model.find("UpCombiner"+numtostring(i)),Model.find("UpCoveyor"+numtostring(i)),  "A");

}


//入库source1
for(int i=1; i<=PutConveyorNum;i++){
   treenode librarySource = maintree().find("project/userlibrary/UserLibrary 1/source1");
   Object firstSource = createinstance(librarySource, model());//创建Soure

   setvarnum(firstSource, "itemclass", 7);

   firstSource.name="source1"+numtostring(i);
   firstSource.setSize(1,1,0.5);
   firstSource.location.x = xloc(Model.find("UpCombiner"+numtostring(i)))-1;
   firstSource.location.y = yloc(Model.find("UpCombiner"+numtostring(i)))+4;

int WorkModel=Table("模式选择")[9][2];

   if(WorkModel!=2)
	{
   contextdragconnection(Model.find("source1"+numtostring(i)),Model.find("UpCombiner"+numtostring(i)),  "A");
	}
}

//入库source2
for(int i=1; i<=PutConveyorNum;i++){
   treenode librarySource2 = maintree().find("project/userlibrary/UserLibrary 1/source2");
   Object secondSource = createinstance(librarySource2, model());//创建Soure

   setvarnum(secondSource, "itemclass", 1);

   secondSource.name="source2"+numtostring(i);
   secondSource.setSize(1,1,0.5);
   secondSource.location.x = xloc(Model.find("UpCombiner"+numtostring(i)))+1;
   secondSource.location.y = yloc(Model.find("UpCombiner"+numtostring(i)))+4;

int WorkModel=Table("模式选择")[9][2];

   if(WorkModel!=2)
	{
   contextdragconnection(Model.find("source2"+numtostring(i)),Model.find("UpCombiner"+numtostring(i)),  "A");
	}
}
