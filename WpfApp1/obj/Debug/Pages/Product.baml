   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.PagesWpfApp1.Pages  5          WpfApp1.Pages.Product   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Pages     5      -   5          N� Title$  Product��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      -   5         ��Name$ SplitterColumn��5   )   $��0 �6   6)   �� 5      -   5        $ ChangeColumn��5   )   $��0 �6   $	��250��6?    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   �� 
�������$��0��6!   $��0��6.   $��3��6>   �� 5   
   $��Мебель��6   $��3��6"   $��26(�64   $��	ExtraBold"�6B   $
��Left=�6Y   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5         ��Name$ AddBook��5      $��
Новая��6&   $��75��66   $	��5,5q�6A   6N   �� 5      -   5        $ CopyBook��5      $��Копировать��6'   $��75��6<   $	��5,5q�6G   6T   �� 5      -   5        $ EditBook��5      $��Изменить��6'   $��75��6:   $	��5,5q�6E   6R   �� 5      -   5        $ 
DeleteBook��5      $��Удалить��6)   $��75��6;   $	��5,5q�6F   6S   �� 5      -   5        $��TypeObjectsFilterComboBox��5      $	��150��68   $	��5,5q�6D   6Q   �� 5      -	   5         ��Name$ TypeObjectsFilterTextBox��5      $	��200��68   $	��5,5q�6D   6Q   5      &   System.Windows.Controls.DataGrid  5    
   -
   5          Name$ DataGridProduct��5       $��2��6,   $��0��69      AutoGenerateColumns .  	   CanUserAddRows	 .  
   Columns
 5!      4  .System.Windows.Controls.DataGridTemplateColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Тип мебели��5%   5      CellTemplate 5&      �� 5'      .R�5(      �� ��6$   �� *id_type_of_furniture+5)      5+        5,      $ Количество��5/   5    50      �� 51      .R�52      �� ��6$   �� *quantity_product+53      55        56      $ Поставщик��59   5    5:      �� 5;      .R�5<      �� ��6$   �� *id_suppliers+5=      5?        5@      $ Цена��5C   5    5D      �� 5E      .R�5F      �� ��6$   �� *price+5G      5I        5J      $ Цвет��5M   1    5N      �� 5O      .R�5P      �� ��6    �� *color+5Q      5S        5T         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)   $# Название мебели��5W   5    5X      �� 5Y      .R�5Z      �� ��6$   �� *name_product+5[      5]      5`      �� 5a   
   $��1��6   $��1��6'   $��2��64   $��Center=�6E   $��5��6b   �� 5c   
   -   5        $��X��5c      $��2��6   $��1��6-   $��Right=�6:   $	��Top=�6V   $��20��6�   $��20��6�   �� 5d   
   $��2��6   $��2��6'   .��5e      �� $ Vertical=�6   .+�5f      �� $��Мебель��6   $��4��6)   $��2��69   $
��Left=�6F   $��16(�6a   $��Italic$�6o   �� 5g      $��Тип мебели��6   
���   �6/   �� 5h      -   5         ��Name$ ComboBoxType��5h       �� DisplayMemberPath$
 name��61    �� Text 6K   �� *64SelectedItem.types_of_furniture.id_type_of_furniture+ �� ElementName$ DataGridProduct���� 5i      $��Цвет��6   
���   �6)   �� 5j      -   5        $ ColorTextBox��5j   `   ��6   �� $ DataGridProduct�� �� Path$ SelectedItem.color�6`   �� 5k      $��Количество��6   
���   �6/   �� 5l      -   5        $ QuantTextBox��5l   k   ��6   �� $ DataGridProduct��$# SelectedItem.quantity_product�6k   �� 5m      $��Поставщик��6   
���   �6.   �� 5n      -   5        $ ComboBoxSupp��5n      $
 name��61    6K   �� *$"SelectedItem.Position.id_suppliers+$ DataGridProduct���� 5o      $��Цена��6   
���   �6)   �� 5p      -   5        $ PriceTextBox��5p   `   ��6   �� $ DataGridProduct��$ SelectedItem.price�6`   �� 5r      $#��Название мебели��6   
���   �64   �� 5s      -   5        $ NameTextBox��5s   g   ��6   �� $ DataGridProduct��$ SelectedItem.name_product�6g   �� 5t      -   5        $��Принять��5t      $��	0 10 0 10q�6C   5u      5v      5w      5x      