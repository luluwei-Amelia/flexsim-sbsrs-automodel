int racknum = Table("RackTable")[1][2];
int Tier = Table("RackTable")[3][2];
double QueueLength = Table("QueueTable")[1][2];
double QueueWidth = Table("QueueTable")[2][2];

int WorkModel=Table("模式选择")[9][2];

//创建出库Queue
	treenode libraryQueue = library().find("?Queue");
	Object firstQueue = createinstance(libraryQueue, model());//创建Soure
	firstQueue.name="OutQueue";
	firstQueue.setSize(QueueLength,QueueWidth,0.2);
	firstQueue.location.x = xloc(Model.find("Combiner"));
	firstQueue.location.y = yloc(Model.find("Combiner"))-5;
	firstQueue.location.z = 0;

//创建出库source
 //treenode librarySource = createinstance(maintree().find("project/userlibrary/UserLibrary 1/OutSource"), model());
  treenode librarySource = maintree().find("project/userlibrary/UserLibrary 1/OutSource");

  Object firstSource = createinstance(librarySource, model());//创建Soure
  setvarnum(firstSource, "itemclass", 1);
  firstSource.name="OutSource";
  firstSource.setSize(1,1,0.5);
  firstSource.location.x = xloc(Model.find("OutQueue"))-3;
  firstSource.location.y = yloc(Model.find("OutQueue"));

   if(WorkModel!=1)
	{
  contextdragconnection(Model.find("OutSource"),Model.find("OutQueue"),  "A");
	}


//创建出库Sink
treenode librarySink = library().find("?Sink");
Object firstSink = createinstance(librarySink, model());
firstSink.name="chukuSink";
firstSink.setSize(1,1,0.5);
firstSink.location.x = xloc(Model.find("OutQueue"))+3;
firstSink.location.y = yloc(Model.find("OutQueue"));


   if(WorkModel!=1)
	{
    contextdragconnection(Model.find("OutQueue"),Model.find("chukuSink"),"A");
	}


//contextdragconnection(Model.find("chukuQueue"),Model.find("chukuSink"),"A");
