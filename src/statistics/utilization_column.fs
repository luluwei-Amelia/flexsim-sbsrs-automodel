/**Custom Code*/
StatisticsCollector collector = ownerobject(c);
var data = collector.collectedData;
treenode current = data.eventNode;
Object instance = data.processFlowInstance;

Table Shuttle=Table("TaskExecuterBarChart");
int rows=Shuttle.numRows;

Table a=Table.query("Select Idle From [TaskExecuterBarChart]");
Table b=Table.query("Select OffsetTravelEmpty From [TaskExecuterBarChart]");
Table c=Table.query("Select OffsetTravelLoaded From [TaskExecuterBarChart]");
Table d=Table.query("Select Loading From [TaskExecuterBarChart]");
Table e=Table.query("Select Unloading From [TaskExecuterBarChart]");
double asum=0;
double bsum=0;
double csum=0;
double dsum=0;
double esum=0;
for(int i=1;i<=rows;i++)
{
	asum=asum+a[i][1];
	bsum=bsum+b[i][1];
	csum=csum+c[i][1];
	dsum=dsum+d[i][1];
	esum=esum+e[i][1];
}

return (bsum+csum+dsum+esum)/(asum+bsum+csum+dsum+esum);
