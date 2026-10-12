/**Custom Code*/
int numrow = Table("RackTable")[1][2];//排数
int numbay= Table("RackTable")[2][2] ;// 列数
int numlevels = Table("RackTable")[3][2];// 层数

double levelHeight = Table("RackTable")[6][2];// 货位高（单层高）

int ShuttleNum = Table("ShuttleTable")[4][2];

double ShuttleLength = Table("ShuttleTable")[1][2];
double ShuttleWidth = Table("ShuttleTable")[2][2];
double ShuttleHeight = Table("ShuttleTable")[3][2];

double ShuttleMaxSpeed=Table("ShuttleTable")[5][2];
double ShuttleAcceleration=Table("ShuttleTable")[6][2];
double ShuttleDeceleration=Table("ShuttleTable")[7][2];

//设置小车标签
string labelname1 = "bianhao";
string labelname2 = "Cur_Tier";
string labelname3 = "Des_Tier";

for(int i=1;i<=numrow/2;i++){
	for(int j=1;j<=ShuttleNum;j++){

	treenode libraryTaskExecuter = library().find("?TaskExecuter");
	Object firstTaskExecuter = createinstance(libraryTaskExecuter, model());
	firstTaskExecuter.name="TaskExecuter"+numtostring(i)+numtostring(j);

	setvarnum(firstTaskExecuter, "modifyrotation", 0);
	setvarnum(firstTaskExecuter, "useoffsets", 0);

	setvarnum(firstTaskExecuter, "maxspeed", ShuttleMaxSpeed);
	setvarnum(firstTaskExecuter, "acceleration", ShuttleAcceleration);
	setvarnum(firstTaskExecuter, "deceleration", ShuttleDeceleration);

	firstTaskExecuter.labels.assert(labelname1).value = j;
	firstTaskExecuter.labels.assert(labelname2).value = j;
	firstTaskExecuter.labels.assert(labelname3).value = j;


	firstTaskExecuter.setSize(ShuttleLength,ShuttleWidth,ShuttleHeight);
	firstTaskExecuter.location.x = xloc(Model.find("Rack"+numtostring(2*i-1)));
	firstTaskExecuter.location.y = (yloc(Model.find("Rack"+numtostring(2*i-1)))+yloc(Model.find("Rack"+numtostring(2*i)))-0.5)/2;
	firstTaskExecuter.location.z = (j-1)*levelHeight;

	firstTaskExecuter.labels.assert("X_Init").value = firstTaskExecuter.location.x;
	firstTaskExecuter.labels.assert("Y_Init").value = firstTaskExecuter.location.y;
	firstTaskExecuter.labels.assert("Z_Init").value = firstTaskExecuter.location.z;
	firstTaskExecuter.labels.assert("Aisle_Init").value = i;
	firstTaskExecuter.labels.assert("Aisle").value = i;
	firstTaskExecuter.labels.assert("Bay").value = 0;


	}

}
