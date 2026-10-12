/**Custom Code*/

int RowNum = Table("RackTable")[1][2];
int TierNum = Table("RackTable")[3][2];
int AisleNum = Table("RackTable")[8][2];
double Height = Table("RackTable")[6][2];


double EleLength = Table("ElevatorTable")[1][2];
double EleWidth = Table("ElevatorTable")[2][2];
double EleHeight = Table("ElevatorTable")[3][2];

double CaseWidth = Table("RackTable")[4][2]; // 货位宽
double CaseLength = Table("RackTable")[5][2];// 货格长（排宽）
double CaseHeight = Table("RackTable")[6][2];// 货位高（单层高）


double BufferLength = Table("RackTable")[11][2];
double BufferWidth = Table("RackTable")[12][2];
double BufferHeight = Table("RackTable")[13][2];

double EleMaxSpeed=Table("ElevatorTable")[4][2];
double EleAcceleration=Table("ElevatorTable")[5][2];
double EleDeceleration=Table("ElevatorTable")[6][2];

int ShuttleNum = Table("ShuttleTable")[4][2];

double ShuttleLength = Table("ShuttleTable")[1][2];
double ShuttleWidth = Table("ShuttleTable")[2][2];
double ShuttleHeight = Table("ShuttleTable")[3][2];

double ShuttleMaxSpeed=Table("ShuttleTable")[5][2];
double ShuttleAcceleration=Table("ShuttleTable")[6][2];
double ShuttleDeceleration=Table("ShuttleTable")[7][2];

//设置电梯标签
string labelname1 = "Lift_Row";
string labelname2 = "Lift_Aisle";

//产生提升机
for(int i=1;i<=RowNum;i++){

    treenode libraryElevator = library().find("?Elevator");
    Object firstElevator = createinstance(libraryElevator, model());//创建Elevator
    firstElevator.name="Elevator"+numtostring(i);

	setvarnum(firstElevator, "maxspeed", EleMaxSpeed);
	setvarnum(firstElevator, "acceleration", EleAcceleration);
	setvarnum(firstElevator, "deceleration", EleDeceleration);

    firstElevator.labels.assert(labelname1).value = i;

    firstElevator.setSize(EleLength,EleWidth,EleHeight);
    firstElevator.location.x = xloc(Model.find("Rack"+numtostring(i)))-BufferLength*2-EleLength-1;
    firstElevator.location.y = yloc(Model.find("Rack"+numtostring(i)));

};
//设置电梯高度
for(int i=1;i<=RowNum;i++)
{
	Model.find("Elevator"+numtostring(i)+">visual/drawsurrogate/Legs").as(Object).size.z=TierNum*CaseHeight;
}


//产生换层提升机
for(int i=1;i<=RowNum/2;i++){
    treenode libraryElevator = library().find("?Elevator");
    Object firstElevator = createinstance(libraryElevator, model());
    firstElevator.name="Elevator"+numtostring(i)+numtostring(3);

	setvarnum(firstElevator, "maxspeed", EleMaxSpeed);
	setvarnum(firstElevator, "acceleration", EleAcceleration);
	setvarnum(firstElevator, "deceleration", EleDeceleration);

    firstElevator.labels.assert(labelname2).value = i;

    firstElevator.setSize(EleLength,EleWidth,EleHeight);
    firstElevator.location.x = xloc(Model.find("Rack"+numtostring(2*i-1)))-BufferLength*2-EleLength-1;
    firstElevator.location.y = (yloc(Model.find("Rack"+numtostring(2*i-1)))+yloc(Model.find("Rack"+numtostring(2*i)))-0.5)/2;
}
//设置电梯高度
for(int i=1;i<=RowNum/2;i++)
{
	Model.find("Elevator"+numtostring(i)+numtostring(3)+">visual/drawsurrogate/Legs").as(Object).size.z=TierNum*CaseHeight;
}
//创建换层电梯Group
string groupname="Elevator_Group";
Group group=Group(groupname);
for(int i=1; i<=RowNum/2;i++){
	treenode newmember=Model.find("Elevator"+numtostring(i)+numtostring(3));
	group.addMember(newmember);
};


//入库端提升机
for(int i=1;i<=AisleNum;i++){
	Object firstElevator = createinstance(library().find("?Elevator"), model());

	setvarnum(firstElevator, "useoffsets",1);

	setvarnum(firstElevator, "maxspeed", EleMaxSpeed);
	setvarnum(firstElevator, "acceleration", EleAcceleration);
	setvarnum(firstElevator, "deceleration", EleDeceleration);

	firstElevator.name="InElevator"+numtostring(i);
	firstElevator.setSize(EleLength,EleWidth,EleHeight);
	firstElevator.location.x = xloc(Model.find("Rack"+numtostring(2*i-1)))+TierNum*CaseLength+1+BufferLength;
	firstElevator.location.y = yloc(Model.find("Rack"+numtostring(2*i-1)));
};
for(int i=1;i<=AisleNum;i++)
{
	Model.find("InElevator"+numtostring(i)+">visual/drawsurrogate/Legs").as(Object).size.z=TierNum*CaseHeight;
}
