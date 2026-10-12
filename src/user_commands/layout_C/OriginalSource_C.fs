/**Custom Code*/
int numRow = Table("RackTable")[1][2];//排数
int numBay = Table("RackTable")[2][2] ;// 列数
int numTIer = Table("RackTable")[3][2];// 层数
double bayWidth = Table("RackTable")[4][2]; // 货位宽

int all = numRow*numBay*numTIer;

//初始Combiner
treenode libraryCombiner = library().find("?Combiner");
Object firstCombiner = createinstance(libraryCombiner, model());//创建Combiner
firstCombiner.name="originalCombiner";
firstCombiner.setSize(3,3,1);
firstCombiner.location.x = xloc(Model.find("Rack"))+bayWidth*numBay+5;
firstCombiner.location.y = yloc(Model.find("Rack"))-20;

for(int i=1; i<=numRow;i++){
contextdragconnection(Model.find("originalCombiner"),Model.find("Rack"+numtostring(i)),  "A");
}

//初始source1
treenode librarySource = library().find("?Source");
Object firstSource = createinstance(librarySource, model());//创建Soure

setvarnum(firstSource, "itemclass", 7);
setvarnum(firstSource, "arrivalmode", 2);

firstSource.name="originalSource1";
firstSource.setSize(1,1,0.5);
firstSource.location.x = xloc(Model.find("originalCombiner"))+3;
firstSource.location.y = yloc(Model.find("originalCombiner"))+2;

contextdragconnection(Model.find("originalSource1"),Model.find("originalCombiner"),  "A");

treenode schedule = getvarnode(Model.find("originalSource1"), "schedule");
for(int i=2;i<=all/2;i++)
{
	treenode ArrivalTime2 = getvarnode(Model.find("originalSource1"), "schedule").subnodes[1];
	schedule.subnodes.add();
	createcopy(ArrivalTime2,getvarnode(Model.find("originalSource1"), "schedule").subnodes[i],0,0,0,1);
}

//初始source2
treenode librarySource1 = library().find("?Source");
Object secondSource = createinstance(librarySource1, model());//创建Soure

setvarnum(secondSource, "itemclass", 1);
setvarnum(secondSource, "arrivalmode", 2);

secondSource.name="originalSource2";
secondSource.setSize(1,1,0.5);
secondSource.location.x = xloc(Model.find("originalCombiner"))+3;
secondSource.location.y = yloc(Model.find("originalCombiner"))-2;

contextdragconnection(Model.find("originalSource2"),Model.find("originalCombiner"),  "A");

treenode schedule2 = getvarnode(Model.find("originalSource2"), "schedule");
for(int j=2;j<=all/2;j++)
{
	treenode ArrivalTime = getvarnode(Model.find("originalSource2"), "schedule").subnodes[1];
	schedule2.subnodes.add();
	createcopy(ArrivalTime,getvarnode(Model.find("originalSource2"), "schedule").subnodes[j],0,0,0,1);
}
