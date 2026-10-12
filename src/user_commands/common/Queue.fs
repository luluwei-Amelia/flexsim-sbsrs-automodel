/**Custom Code*/

int racknum = Table("RackTable")[1][2];
int Tier = Table("RackTable")[3][2];
double Height = Table("RackTable")[6][2];

double BufferLength = Table("RackTable")[11][2];
double BufferWidth = Table("RackTable")[12][2];
double BufferHeight = Table("RackTable")[13][2];

for(int i=1;i<=racknum;i++){
	for(int j=1;j<=Tier;j++){

	treenode libraryQueue = library().find("?Queue");
	Object firstQueue = createinstance(libraryQueue, model());//创建Soure
	firstQueue.name="Queue"+numtostring(i)+numtostring(j);
	firstQueue.setSize(BufferLength,BufferWidth,BufferHeight);
	firstQueue.location.x = xloc(Model.find("Rack"+numtostring(i)))-1.5;
	firstQueue.location.y = yloc(Model.find("Rack"+numtostring(i)));
	firstQueue.location.z = (j-1)*Height;
	setvarnum(firstQueue, "usetransport",1);

	}

}

for(int i=1;i<=racknum/2;i++){
	for(int j=1;j<=Tier;j++){
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
