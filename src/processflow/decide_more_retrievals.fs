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
	if (length<=InLots)
		return 1;
	else return 2;
}
return 2;
