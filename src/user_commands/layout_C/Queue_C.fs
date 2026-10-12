/**Custom Code*/

int RowNum = Table("RackTable")[1][2];
int TierNum = Table("RackTable")[3][2];
int AisleNum = Table("RackTable")[8][2];
double Height = Table("RackTable")[6][2];

double CaseLength = Table("RackTable")[5][2];
double CaseWidth = Table("RackTable")[4][2];
double CaseHeight = Table("RackTable")[6][2];

double BufferLength = Table("RackTable")[11][2];
double BufferWidth = Table("RackTable")[12][2];
double BufferHeight = Table("RackTable")[13][2];


//产生缓冲区
for(int i=1;i<=RowNum;i++){
	for(int j=1;j<=TierNum;j++){

	treenode libraryQueue = library().find("?Queue");
	Object firstQueue = createinstance(libraryQueue, model());//创建Soure
	firstQueue.name="Queue"+numtostring(i)+numtostring(j);
	firstQueue.setSize(BufferLength,BufferWidth,BufferHeight);
	firstQueue.location.x = xloc(Model.find("Rack"+numtostring(i)))-1.5;
	firstQueue.location.y = yloc(Model.find("Rack"+numtostring(i)))-0.5;
	firstQueue.location.z = (j-1)*Height;
	setvarnum(firstQueue, "usetransport",1);
	}
}

//产生换层缓冲区
for(int i=1;i<=RowNum/2;i++){
	for(int j=1;j<=TierNum;j++){
treenode libraryQueue3 = library().find("?Queue");
Object firstQueue3 = createinstance(libraryQueue3, model());
firstQueue3.name="Q"+numtostring(i)+numtostring(j);
firstQueue3.setSize(BufferLength,BufferWidth,BufferHeight);

	firstQueue3.location.x = xloc(Model.find("Rack"+numtostring(i)))-1.5;
	firstQueue3.location.y = (yloc(Model.find("Rack"+numtostring(2*i-1)))+yloc(Model.find("Rack"+numtostring(2*i)))-0.5)/2;
	firstQueue3.location.z = (j-1)*Height;
	setvarnum(firstQueue3, "usetransport",1);
  }
 }

//入库端缓冲区
for(int i=1;i<=AisleNum;i++){
	for(int j=1;j<=TierNum;j++){

	treenode libraryQueue = library().find("?Queue");
	Object firstQueue4 = createinstance(libraryQueue, model());
	firstQueue4.name="InQueue"+numtostring(i)+numtostring(j);
	firstQueue4.setSize(BufferLength,BufferWidth,BufferHeight);
	firstQueue4.location.x = xloc(Model.find("Rack"+numtostring(2*i-1)))+TierNum*CaseLength;
	firstQueue4.location.y = yloc(Model.find("Rack"+numtostring(2*i-1)))-0.5;
	firstQueue4.location.z = (j-1)*CaseHeight;

	setvarnum(firstQueue4, "usetransport",1);

	}
}
