/**Custom Code*/
Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);

int InLots=Table("Initial")[3][3];

treenode schedule = getvarnode(Model.find("OutSource"), "schedule");

int length=schedule.subnodes.length;
int WorkModel=Table("模式选择")[9][2];
if(WorkModel!=1)
{
	if(length<=InLots)
	{
		treenode ArrivalTime1 = schedule.subnodes[1];
		treenode ArrivalTime = schedule.subnodes.add();
		createcopy(ArrivalTime1,ArrivalTime,0,0,0,1);
		double t=time();
		ArrivalTime.subnodes[1].value=t;
		ArrivalTime.name="Arrival"+numtostring(length+1);
	}
}
