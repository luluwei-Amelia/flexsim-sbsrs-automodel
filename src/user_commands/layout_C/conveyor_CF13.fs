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

//Out
//入库
for(int i=1;i<=AisleNum ;i++){
	treenode newConveyor = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor,AisleConveyorLength,ConveyorWidth,ConveyorHeight);

	setloc(newConveyor,xloc(Model.find("Elevator"+numtostring(2*i-1)))-AisleConveyorLength,yloc(Model.find("Elevator"+numtostring(2*i-1)))-1,ConveyorHeight);
	function_s(newConveyor, "finalizeSpatialChanges");//设置为自动连接
	for(int j=1;j<=TierNum;j++){
		contextdragconnection(Model.find("Conveyor"+numtostring(i)),Model.find("Queue"+numtostring(2*i-1)+numtostring(j)),"A");
	}

	contextdragconnection(Model.find("ExitTransfer"+numtostring(i)),Model.find("Elevator"+numtostring(2*i-1)),"S");
	setnodenum(Model.find("ExitTransfer"+numtostring(i)+">variables/localExitType/useTransport"),1);
}
//出库
for(int i=1;i<=AisleNum ;i++){
	treenode newConveyor = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor,AisleConveyorLength,ConveyorWidth,ConveyorHeight);
	setrot(newConveyor,0,0,180);
	setloc(newConveyor,xloc(Model.find("Elevator"+numtostring(2*i))),yloc(Model.find("Elevator"+numtostring(2*i)))-1,ConveyorHeight);
	function_s(newConveyor, "finalizeSpatialChanges");//设置为自动连接

	for(int j=1;j<=TierNum;j++){
		contextdragconnection(Model.find("Queue"+numtostring(2*i)+numtostring(j)),Model.find("Conveyor"+numtostring(i+AisleNum)),"A");
		contextdragconnection(Model.find("Queue"+numtostring(2*i)+numtostring(j)),Model.find("Elevator"+numtostring(2*i)),"S");

	}
}

double mainLength=yloc(Model.find("Conveyor"+numtostring(RowNum)))-yloc(Model.find("Conveyor"+numtostring(1)));
//主输送线
treenode newConveyor1 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor1,mainLength+2*MainConveyorExtend,1,1);
setloc(newConveyor1,xloc(Model.find("Conveyor1"))-0.5,yloc(Model.find("Conveyor1"))-MainConveyorExtend,ConveyorHeight);
setrot(newConveyor1,0,0,90);
function_s(newConveyor1, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor1,"mainconveyor");

//创建DP总控点，设置于主输送线上
treenode newPoint = createinstance(maintree().find("project/userlibrary/UserLibrary 1/mainDP"), model());
setloc(newPoint,xloc(Model.find("mainconveyor")),yloc(Model.find("mainconveyor"))+1,ConveyorHeight);
function_s(newPoint, "finalizeSpatialChanges");
setname(newPoint,"mainDP");

//创建支流控制点
for(int j=1;j<=AisleNum;j++){

		treenode newPoint1 = createinstance(node("conveyor/DecisionPoint", library()), model());
		setloc(newPoint1,xloc(Model.find("Conveyor"+numtostring(j))),yloc(Model.find("Conveyor"+numtostring(j))),ConveyorHeight);
		function_s(newPoint1, "finalizeSpatialChanges");
		newPoint1.name="DP"+numtostring(j);

}
//创建A连接
for(int i=1; i<=AisleNum; i++){
	contextdragconnection(Model.find("mainDP"),Model.find("DP"+numtostring(i)),"A");
};

//int corner=4;

//主输送线
treenode newConveyor2 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor2,CircleConveyorWidth,1,1);
setloc(newConveyor2,xloc(Model.find("mainconveyor"))-CircleConveyorWidth,yloc(Model.find("mainconveyor")),ConveyorHeight);
setrot(newConveyor2,0,0,0);
function_s(newConveyor2, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor2,"mainconveyor1");

//主输送线
treenode newConveyor3 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor3,mainLength+2*MainConveyorExtend,1,1);
setloc(newConveyor3,xloc(Model.find("mainconveyor1")),yloc(Model.find("mainconveyor1"))+mainLength+2*MainConveyorExtend,ConveyorHeight);
setrot(newConveyor3,0,0,270);
function_s(newConveyor3, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor3,"mainconveyor2");

treenode newConveyor4 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor4,CircleConveyorWidth,1,1);
setloc(newConveyor4,xloc(Model.find("mainconveyor2"))+CircleConveyorWidth,yloc(Model.find("mainconveyor2")),ConveyorHeight);
setrot(newConveyor4,0,0,180);
function_s(newConveyor4, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor4,"mainconveyor3");


//In
//入库
for(int i=1;i<=AisleNum ;i++){
	treenode newConveyor = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor,AisleConveyorLength,ConveyorWidth,ConveyorHeight);
	setloc(newConveyor,xloc(Model.find("InElevator"+numtostring(i)))+EleLength+AisleConveyorLength,yloc(Model.find("InElevator"+numtostring(i)))-EleWidth/2,ConveyorHeight);
	setrot(newConveyor,0,0,180);
	function_s(newConveyor, "finalizeSpatialChanges");//设置为自动连接
	setname(newConveyor,"InConveyor"+numtostring(i));
	for(int j=1;j<=TierNum;j++){
		contextdragconnection(Model.find("InConveyor"+numtostring(i)),Model.find("InQueue"+numtostring(i)+numtostring(j)),"A");
	}

	contextdragconnection(Model.find("ExitTransfer"+numtostring(i+AisleNum)),Model.find("InElevator"+numtostring(i)),"S");
	setnodenum(Model.find("ExitTransfer"+numtostring(i)+">variables/localExitType/useTransport"),1);
}

//主输送线
treenode newConveyor11 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor11,mainLength+2*MainConveyorExtend,1,1);
setloc(newConveyor11,xloc(Model.find("InConveyor1"))+0.5,yloc(Model.find("InConveyor1"))-MainConveyorExtend,ConveyorHeight);
setrot(newConveyor11,0,0,90);
function_s(newConveyor11, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor11,"Inmainconveyor");
function_s(Model.find("Inmainconveyor"), "switchDirection");

//创建DP总控点，设置于主输送线上
treenode newPoint2 = createinstance(maintree().find("project/userlibrary/UserLibrary 1/mainDP"), model());
setloc(newPoint2,xloc(Model.find("Inmainconveyor")),yloc(Model.find("Inmainconveyor"))-1,ConveyorHeight);
function_s(newPoint2, "finalizeSpatialChanges");
setname(newPoint2,"InmainDP");

//创建支流控制点
for(int j=1;j<=AisleNum;j++){

		treenode newPoint1 = createinstance(node("conveyor/DecisionPoint", library()), model());
		setloc(newPoint1,xloc(Model.find("InConveyor"+numtostring(j)))-1,yloc(Model.find("InConveyor"+numtostring(j))),ConveyorHeight);
		function_s(newPoint1, "finalizeSpatialChanges");
		newPoint1.name="InDP"+numtostring(j);

}
//创建A连接
for(int i=1; i<=AisleNum; i++){
	contextdragconnection(Model.find("InmainDP"),Model.find("InDP"+numtostring(i)),"A");
};


//主输送线
treenode newConveyor12 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor12,CircleConveyorWidth,1,1);
setloc(newConveyor12,xloc(Model.find("Inmainconveyor")),yloc(Model.find("Inmainconveyor"))-(mainLength+2*MainConveyorExtend),ConveyorHeight);
setrot(newConveyor12,0,0,0);
function_s(newConveyor12, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor12,"Inmainconveyor1");

//主输送线
treenode newConveyor13 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor13,mainLength+2*MainConveyorExtend+CircleConveyorWidth,1,1);
setloc(newConveyor13,xloc(Model.find("Inmainconveyor1"))+CircleConveyorWidth,yloc(Model.find("Inmainconveyor1")),ConveyorHeight);
setrot(newConveyor13,0,0,90);
function_s(newConveyor13, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor13,"Inmainconveyor2");

treenode newConveyor14 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor14,CircleConveyorWidth+LInConveyorLength,1,1);
setloc(newConveyor14,xloc(Model.find("Inmainconveyor2")),yloc(Model.find("Inmainconveyor2"))+mainLength+2*MainConveyorExtend+CircleConveyorWidth,ConveyorHeight);
setrot(newConveyor14,0,0,180);
function_s(newConveyor14, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor14,"Inmainconveyor3");

treenode newConveyor15 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor15,CircleConveyorWidth,1,1);
setloc(newConveyor15,xloc(Model.find("Inmainconveyor3"))-(CircleConveyorWidth+LInConveyorLength),yloc(Model.find("Inmainconveyor3")),ConveyorHeight);
setrot(newConveyor15,0,0,270);
function_s(newConveyor15, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor15,"Inmainconveyor4");

treenode newConveyor16 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor16,LInConveyorLength,1,1);
setloc(newConveyor16,xloc(Model.find("Inmainconveyor4")),yloc(Model.find("Inmainconveyor4"))-CircleConveyorWidth,ConveyorHeight);
setrot(newConveyor16,0,0,0);
function_s(newConveyor16, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor16,"Inmainconveyor5");


//输送线基本参数
treenode speed=Model.find("ConveyorSystem>variables/conveyorTypes/ConveyorType1/speed");
speed.value=ConveyorSpeed;
treenode width=Model.find("ConveyorSystem>variables/conveyorTypes/ConveyorType1/width");
width.value=ConveyorWidth;
treenode legHeight=Model.find("ConveyorSystem>variables/conveyorTypes/ConveyorType1/legHeight");
legHeight.value=ConveyorHeight;
