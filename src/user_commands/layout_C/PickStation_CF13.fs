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

//创建分拣输送线(分拣台）
for(int i=1;i<=SortConveyorNum;i++)
{
	treenode newConveyor8 = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor8,SortConveyorSize2,1,1);
	setloc(newConveyor8,xloc(Model.find("mainconveyor2")),yloc(Model.find("mainconveyor3"))-FirstSortConveyorLocation-(SortConveyorInterval)*(i-1)-SortConveyorSize1*(i-1),ConveyorHeight);
	setrot(newConveyor8,0,0,180);
	function_s(newConveyor8, "finalizeSpatialChanges");//设置为自动连接
    setname(newConveyor8,"pickcoveyor"+numtostring(i)+numtostring(1));

	treenode newConveyor9 = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor9,SortConveyorSize1,1,1);
	setloc(newConveyor9,xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(1)))-SortConveyorSize2,yloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(1))),ConveyorHeight);
	setrot(newConveyor9,0,0,270);
	function_s(newConveyor9, "finalizeSpatialChanges");//设置为自动连接
    setname(newConveyor9,"pickcoveyor"+numtostring(i)+numtostring(2));

	treenode newConveyor10 = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor10,SortConveyorSize2,1,1);
	setloc(newConveyor10,xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(2))),yloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(2)))-SortConveyorSize1,ConveyorHeight);
	setrot(newConveyor10,0,0,0);
	function_s(newConveyor10, "finalizeSpatialChanges");//设置为自动连接
    setname(newConveyor10,"pickcoveyor"+numtostring(i)+numtostring(3));
}

//设置拣选主DP
treenode newPoint2 = createinstance(maintree().find("project/userlibrary/UserLibrary 1/SortMainDP"), model());
setloc(newPoint2,xloc(Model.find("mainconveyor2")),yloc(Model.find("mainconveyor2"))-FirstSortConveyorLocation+2,ConveyorHeight);
function_s(newPoint2, "finalizeSpatialChanges");
setname(newPoint2,"PickMainDP1");

for(int i=1;i<=SortConveyorNum-1;i++){

		treenode newPoint4 = createinstance(maintree().find("project/userlibrary/UserLibrary 1/SortMainDP"), model());
		setloc(newPoint4,xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(3)))+2,yloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(3))),ConveyorHeight);
		function_s(newPoint4, "finalizeSpatialChanges");
		newPoint4.name="PickMainDP"+numtostring(i+1);
}

//拣选支线DP
for(int i=1;i<=SortConveyorNum;i++){

		treenode newPoint3 = createinstance(node("conveyor/DecisionPoint", library()), model());
		setloc(newPoint3,xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(1)))-2,yloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(1))),ConveyorHeight);
		function_s(newPoint3, "finalizeSpatialChanges");
		newPoint3.name="fenPickDP"+numtostring(i);
		for(int j=1;j<=SortConveyorNum;j++){
		contextdragconnection(Model.find("PickMainDP"+numtostring(j)),Model.find("fenPickDP"+numtostring(i)),"A");
		}
}

//设置拣选工作站
for(int i=1;i<=SortConveyorNum;i++){

		treenode Station = createinstance(maintree().find("project/userlibrary/UserLibrary 1/Station1"), model());
		setloc(Station,xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(2))),yloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(2)))-SortConveyorSize1/2,ConveyorHeight);
		function_s(Station, "finalizeSpatialChanges");
		Station.name="Station"+numtostring(i);

	   treenode StationDP = createinstance(maintree().find("project/userlibrary/UserLibrary 1/StationDP"), model());
	   setloc(StationDP,xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(2)))-0.2,yloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(2)))-SortConveyorSize1/2,ConveyorHeight-1);
	   function_s(StationDP, "finalizeSpatialChanges");
	   StationDP.name="StationDP"+numtostring(i);

}

//创建分拣Operator
for(int i=1;i<=SortConveyorNum;i++){

treenode libraryOperator = library().find("?Operator");
Object firstOperator = createinstance(libraryOperator, model());
firstOperator.name="Operator"+numtostring(i);
//setrot(firstOperator,0,0,270);
firstOperator.setSize(0.7,0.7,2);
firstOperator.location.x = xloc(Model.find("Station"+numtostring(i)))-2;
firstOperator.location.y = yloc(Model.find("Station"+numtostring(i)));
//firstOperator.location.z = ConveyorHeight+LayerTier;

}

//创建Sink
treenode librarySink = library().find("?Sink");
Object firstSink = createinstance(librarySink, model());
setvarnum(firstSink, "pull", 1);
firstSink.name="pickSink";
firstSink.setSize(1,1,0.5);
firstSink.location.x = xloc(Model.find("pickcoveyor12"))-3;
firstSink.location.y = yloc(Model.find("pickcoveyor22"))+3;
//firstSink.location.z = ConveyorHeight+LayerTier;
