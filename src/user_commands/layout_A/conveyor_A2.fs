/**Custom Code*/

int RowNum =Table("RackTable")[1][2];
int AisleNum = Table("RackTable")[8][2];
int TierNum = Table("RackTable")[3][2];

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
double LConveyorLength=Table("ConveyorTable")[14][2];

//入库
for(int i=1;i<=AisleNum ;i++){
	treenode newConveyor = createinstance(node("conveyor/StraightConveyor", library()), model());
	setsize(newConveyor,AisleConveyorLength,1,1);

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
	setsize(newConveyor,AisleConveyorLength,1,1);
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

//主输送线
treenode newConveyor2 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor2,CircleConveyorWidth,1,1);
setloc(newConveyor2,xloc(Model.find("mainconveyor")),yloc(Model.find("mainconveyor"))+mainLength+2*MainConveyorExtend,ConveyorHeight);
setrot(newConveyor2,0,0,180);
function_s(newConveyor2, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor2,"mainconveyor1");

//主输送线
treenode newConveyor3 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor3,mainLength+2*MainConveyorExtend+CircleConveyorWidth,1,1);
setloc(newConveyor3,xloc(Model.find("mainconveyor1"))-CircleConveyorWidth,yloc(Model.find("mainconveyor1")),ConveyorHeight);
setrot(newConveyor3,0,0,270);
function_s(newConveyor3, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor3,"mainconveyor2");

treenode newConveyor4 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor4,CircleConveyorWidth+LConveyorLength,1,1);
setloc(newConveyor4,xloc(Model.find("mainconveyor2")),yloc(Model.find("mainconveyor2"))-(mainLength+2*MainConveyorExtend+CircleConveyorWidth),ConveyorHeight);
setrot(newConveyor4,0,0,0);
function_s(newConveyor4, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor4,"mainconveyor3");

treenode newConveyor5 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor5,CircleConveyorWidth,1,1);
setloc(newConveyor5,xloc(Model.find("mainconveyor3"))+CircleConveyorWidth+LConveyorLength,yloc(Model.find("mainconveyor3")),ConveyorHeight);
setrot(newConveyor5,0,0,90);
function_s(newConveyor5, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor5,"mainconveyor4");

treenode newConveyor6 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newConveyor6,LConveyorLength,1,1);
setloc(newConveyor6,xloc(Model.find("mainconveyor4")),yloc(Model.find("mainconveyor4"))+CircleConveyorWidth,ConveyorHeight);
setrot(newConveyor6,0,0,180);
function_s(newConveyor6, "finalizeSpatialChanges");//设置为自动连接
setname(newConveyor6,"mainconveyor5");

//输送线基本参数
treenode speed=Model.find("ConveyorSystem>variables/conveyorTypes/ConveyorType1/speed");
speed.value=ConveyorSpeed;
treenode width=Model.find("ConveyorSystem>variables/conveyorTypes/ConveyorType1/width");
width.value=ConveyorWidth;
treenode legHeight=Model.find("ConveyorSystem>variables/conveyorTypes/ConveyorType1/legHeight");
legHeight.value=ConveyorHeight;
