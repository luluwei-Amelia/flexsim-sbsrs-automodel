Object button = c;
treenode book = Model.find("Tools/ExcelAuto>variables/importtable/Row_1/Excel_Book_Name");
Object textbox = button.prev.prev;
book.value = getviewtext(textbox);
treenode sheet=Model.find("Tools/ExcelAuto>variables/importtable/Row_1/Excel_Sheet_Name");
Object sheetbox=button.next.next.next;
sheet.value=getviewtext(sheetbox);
