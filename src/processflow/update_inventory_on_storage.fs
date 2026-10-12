/**Custom Code*/
Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);

int StockNo=token.item.StockNo;
int ToteNo=token.item.ToteNo;

int Stock=gettablenum("Inventory",StockNo,6);

settablenum("Inventory",StockNo,6,Stock+1);
settablenum("Inventory",StockNo,7,0);

if(Stock==0)
{
	settablenum("Inventory",StockNo,8,token.item.ToteNo);
	settablenum("Inventory",StockNo,10,token.item.NowParts);
}

if(Stock==1)
{
	settablenum("Inventory",StockNo,9,token.item.ToteNo);
	settablenum("Inventory",StockNo,11,token.item.NowParts);
}

if(Table("OutTable").numRows>0)
{
	Table available=Table.query("SELECT * FROM OutTable WHERE [ToteNo]="+numtostring(ToteNo));
	int k=available.numRows;

	if(k>0)
	{
		int InTimes=gettablenum("ToteTable",ToteNo,4);
		settablenum("ToteTable",ToteNo,4,InTimes+1);
	}
}

token.item.State=1;
token.Shuttle.Bay=token.item.Bay;
