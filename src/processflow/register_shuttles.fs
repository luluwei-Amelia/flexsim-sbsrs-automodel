/**写入列表*/
Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);

double StopTime=Table("Initial")[9][3];

Array arr=Group("Shuttle_Group").toFlatArray();
for(int i=1;i<=arr.length;i++)
{
	List("ShuttleList").push(arr[i],0);
};

int WorkModel=Table("模式选择")[9][2];
if(WorkModel!=2)
{
	stoptime(StopTime);
}
