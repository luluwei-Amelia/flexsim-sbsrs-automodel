/**Custom Code*/
Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);
int WorkModel=Table("模式选择")[9][2];
if(WorkModel==2)
{
	stop();
}
