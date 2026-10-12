/**Custom Code*/
int racknum =Table("RackTable")[1][2];
int AisleNum = Table("RackTable")[8][2];
int TierNum = Table("RackTable")[3][2];
int BayNum = Table("RackTable")[2][2];
int CaseWidth = Table("RackTable")[4][2];

double Length=Table("ConveyorTable")[1][2];
double PickLength=Table("ConveyorTable")[4][2];
double PickWidth=Table("ConveyorTable")[5][2];


double mainLength=3.5*racknum+4;

double ConveyorWidth=Table("ConveyorTable")[10][2];
double ConveyorHeight=Table("ConveyorTable")[3][2];
double ConveyorSpeed=Table("ConveyorTable")[16][2];


//入库
for(int i=1;i<=racknum/2 ;i++){
	treenode newConveyor = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor,Length,1,1);

	setloc(newConveyor,xloc(Model.find("Elevator"+numtostring(2*i-1)))-Length,yloc(Model.find("Elevator"+numtostring(2*i-1)))-1,ConveyorHeight);
	function_s(newConveyor, "finalizeSpatialChanges");//设置为自动连接
	for(int j=1;j<=TierNum;j++){
		contextdragconnection(Model.find("Conveyor"+numtostring(i)),Model.find("Queue"+numtostring(2*i-1)+numtostring(j)),"A");
	}

	contextdragconnection(Model.find("ExitTransfer"+numtostring(i)),Model.find("Elevator"+numtostring(2*i-1)),"S");
	setnodenum(Model.find("ExitTransfer"+numtostring(i)+">variables/localExitType/useTransport"),1);

}
//出库
for(int i=1;i<=racknum/2 ;i++){
	treenode newConveyor = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor,Length,1,1);
	setrot(newConveyor,0,0,180);
	setloc(newConveyor,xloc(Model.find("Elevator"+numtostring(2*i))),yloc(Model.find("Elevator"+numtostring(2*i)))-1,ConveyorHeight);
	function_s(newConveyor, "finalizeSpatialChanges");//设置为自动连接

	for(int j=1;j<=TierNum;j++){
		contextdragconnection(Model.find("Queue"+numtostring(2*i)+numtostring(j)),Model.find("Conveyor"+numtostring(i+AisleNum)),"A");
		contextdragconnection(Model.find("Queue"+numtostring(2*i)+numtostring(j)),Model.find("Elevator"+numtostring(2*i)),"S");

	}
}

treenode newConveyor1 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor1,mainLength,1,1);
setloc(newConveyor1,xloc(Model.find("Elevator1"))-Length-0.5,yloc(Model.find("Elevator1"))-5,ConveyorHeight);
setrot(newConveyor1,0,0,90);
function_s(newConveyor1, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor1,"maincoveyor1");

treenode newConveyor5 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor5,Length,1,1);
setloc(newConveyor5,xloc(Model.find("maincoveyor1")),yloc(Model.find("maincoveyor1"))+mainLength,ConveyorHeight);
setrot(newConveyor5,0,0,180);
function_s(newConveyor5, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor5,"maincoveyor5");

treenode newConveyor6 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor6,mainLength,1,1);
setloc(newConveyor6,xloc(Model.find("maincoveyor5"))-Length,yloc(Model.find("maincoveyor5")),ConveyorHeight);
setrot(newConveyor6,0,0,270);
function_s(newConveyor6, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor6,"maincoveyor6");

treenode newConveyor7 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor7,Length,1,1);
setloc(newConveyor7,xloc(Model.find("maincoveyor6")),yloc(Model.find("maincoveyor6"))-mainLength,ConveyorHeight);
function_s(newConveyor7, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor7,"maincoveyor7");


//创建DP总控点，设置于主输送线上
treenode newPoint = createinstance(maintree().find("project/userlibrary/UserLibrary 1/mainDP"), model());
setloc(newPoint,xloc(Model.find("maincoveyor1")),yloc(Model.find("maincoveyor1")),ConveyorHeight);
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

//输送线基本参数
treenode speed=Model.find("ConveyorSystem>variables/conveyorTypes/ConveyorType1/speed");
speed.value=ConveyorSpeed;
treenode width=Model.find("ConveyorSystem>variables/conveyorTypes/ConveyorType1/width");
width.value=ConveyorWidth;
treenode legHeight=Model.find("ConveyorSystem>variables/conveyorTypes/ConveyorType1/legHeight");
legHeight.value=ConveyorHeight;
