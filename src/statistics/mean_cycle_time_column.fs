/**Custom Code*/
StatisticsCollector collector = ownerobject(c);
var data = collector.collectedData;
treenode current = data.eventNode;
Object instance = data.processFlowInstance;

Table Shuttle=Table("TaskExecuterStaytime");
int rows=Shuttle.numRows;

Table a=Table.query("Select Average From [TaskExecuterStaytime]");
double asum=0;

for(int i=1;i<=rows;i++)
{
	asum=asum+a[i][1];
}

double avg=asum/rows;
string r=string.fromNum(avg,2)+"  s";

return r;
