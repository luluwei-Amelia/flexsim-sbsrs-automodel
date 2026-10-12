/**Custom Code*/
int racknum =Table("RackTable")[1][2];
int AisleNum = Table("RackTable")[8][2];
int TierNum = Table("RackTable")[3][2];
int BayNum = Table("RackTable")[2][2];
int CaseWidth = Table("RackTable")[4][2];

double Length=Table("ConveyorTable")[1][2];
double PickLength=Table("ConveyorTable")[4][2];
double PickWidth=Table("ConveyorTable")[5][2];
double PickNum=Table("ConveyorTable")[6][2];



double mainLength=4*racknum+2.5;
double ConveyorHeight=Table("ConveyorTable")[3][2];

//创建分拣输送线(分拣台）
for(int i=1; i<=PickNum;i++){
treenode newpinkConveyor11 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newpinkConveyor11,PickLength,1,1);
setloc(newpinkConveyor11,xloc(Model.find("maincoveyor5"))-i*Length-(i-1)*PickWidth,yloc(Model.find("maincoveyor5")),ConveyorHeight);
setrot(newpinkConveyor11,0,0,90);
function_s(newpinkConveyor11, "finalizeSpatialChanges");//设置为自动连接
setname(newpinkConveyor11,"pickcoveyor"+numtostring(i)+numtostring(1));

treenode newpinkConveyor12 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newpinkConveyor12,PickWidth,1,1);
setloc(newpinkConveyor12,xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(1))),yloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(1)))+PickLength,ConveyorHeight);
setrot(newpinkConveyor12,0,0,180);
function_s(newpinkConveyor12, "finalizeSpatialChanges");//设置为自动连接
setname(newpinkConveyor12,"pickcoveyor"+numtostring(i)+numtostring(2));

treenode newpinkConveyor13 = createinstance(node("conveyor/StraightConveyor", library()), model());
setsize(newpinkConveyor13,PickLength,1,1);
setloc(newpinkConveyor13,xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(2)))-PickWidth,yloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(2))),ConveyorHeight);
setrot(newpinkConveyor13,0,0,270);
function_s(newpinkConveyor13, "finalizeSpatialChanges");//设置为自动连接
setname(newpinkConveyor13,"pickcoveyor"+numtostring(i)+numtostring(3));


}


//创建分拣DP总控点，设置于主输送线上
for(int i=1;i<=PickNum;i++){
        treenode newPoint = createinstance(node("conveyor/DecisionPoint", library()), model());
		setloc(newPoint,xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(1)))+2,yloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(1))),ConveyorHeight);
	    function_s(newPoint, "finalizeSpatialChanges");
        setname(newPoint,"PickMainDP"+numtostring(i));
}


//创建支流控制点
for(int j=1;j<=PickNum;j++){

		treenode newPoint1 = createinstance(node("conveyor/DecisionPoint", library()), model());
		setloc(newPoint1,xloc(Model.find("pickcoveyor"+numtostring(j)+numtostring(1))),yloc(Model.find("pickcoveyor"+numtostring(j)+numtostring(1)))+1,ConveyorHeight);
		function_s(newPoint1, "finalizeSpatialChanges");
		newPoint1.name="fenPickDP"+numtostring(j);
}
//创建A连接
for(int i=1; i<=PickNum; i++){
     for(int j=1;j<=PickNum;j++){
	contextdragconnection(Model.find("PickMainDP"+numtostring(i)),Model.find("fenPickDP"+numtostring(j)),"A");
 }
};

//创建支流Station
for(int j=1;j<=PickNum;j++){
       treenode newPickStation = createinstance(node("conveyor/Station", library()), model());
	   setloc(newPickStation,xloc(Model.find("pickcoveyor"+numtostring(j)+numtostring(2)))-0.5*PickWidth,yloc(Model.find("pickcoveyor"+numtostring(j)+numtostring(2))),ConveyorHeight);
	   function_s(newPickStation, "finalizeSpatialChanges");
	   newPickStation.name="Station"+numtostring(j);

}

//创建Sink
//treenode librarySink = library().find("?Sink");
//Object firstSink = createinstance(librarySink, model());

//firstSink.name="pickSink";
//firstSink.setSize(1,1,0.5);
//firstSink.location.x = xloc(Model.find("pickcoveyor22"));
//firstSink.location.y = yloc(Model.find("pickcoveyor22"))+3;


//创建分拣输送带之间的A连接
//for(int i=1;i<=PickNum;i++){
//	contextdragconnection(Model.find("pickcoveyor"+numtostring(i)+numtostring(2)),Model.find("pickcoveyor"+numtostring(i)+numtostring(3)),"A");

//}

//创建Sink与分拣输送带的A连接
//for(int j=1;j<=PickNum;j++){
//	contextdragconnection(Model.find("ExitTransfer"+numtostring(j+AisleNum)),Model.find("pickSink"),"A");

//}

//创建分拣Operator
for(int i=1;i<=PickNum;i++){

treenode libraryOperator = library().find("?Operator");
Object firstOperator = createinstance(libraryOperator, model());
firstOperator.name="Operator"+numtostring(i);
setrot(firstOperator,0,0,270);
firstOperator.setSize(0.7,0.7,2);
firstOperator.location.x = xloc(Model.find("pickcoveyor"+numtostring(i)+numtostring(2)))-0.5*PickWidth;
firstOperator.location.y = yloc(Model.find("pickcoveyor22"))+2;

}

//创建Sink
treenode librarySink = library().find("?Sink");
Object firstSink = createinstance(librarySink, model());
setvarnum(firstSink, "pull", 1);
firstSink.name="pickSink";
firstSink.setSize(1,1,0.5);
firstSink.location.x = xloc(Model.find("pickcoveyor12"))-3;
firstSink.location.y = yloc(Model.find("pickcoveyor22"))+3;
