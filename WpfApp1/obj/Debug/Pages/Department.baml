   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.PagesWpfApp1.Pages  5          WpfApp1.Pages.Department   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Pages     5      -   5          N� Title$  
Department��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      -   5         ��Name$ SplitterColumn��5   )   $��0 �6   6)   �� 5      -   5        $ ChangeColumn��5   )   $��0 �6   $	��250��6?    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   �� 
�������$��0��6!   $��0��6.   $��3��6>   �� 5   
   $��
Отдел��6   $��3��6!   $��26(�63   $��	ExtraBold"�6A   $
��Left=�6X   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5         ��Name$ AddDep��5      $��
Новая��6%   $��75��65   $	��5,5q�6@   6M   �� 5      -   5        $ CopyDep��5      $��Копировать��6&   $��75��6;   $	��5,5q�6F   6S   �� 5      -   5        $ EditDep��5      $��Изменить��6&   $��75��69   $	��5,5q�6D   6Q   �� 5      -   5        $ 	DeleteDep��5      $��Удалить��6(   $��75��6:   $	��5,5q�6E   6R   �� 5      -   5        $��TypeObjectsFilterComboBox��5      $	��150��68   $	��5,5q�6D   6Q   �� 5      -	   5         ��Name$ TypeObjectsFilterTextBox��5      $	��200��68   $	��5,5q�6D   6Q   5      &   System.Windows.Controls.DataGrid  5    
   -
   5          Name$ DataGridDep��5       $��2��6(   $��0��65      AutoGenerateColumns .  	   CanUserAddRows	 .  
   Columns
 5!      4  .System.Windows.Controls.DataGridTemplateColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$ 
Отдел��5%   5      CellTemplate 5&      �� 5'      .R�5(      �� ��6$   �� *name_department+5)      5+      5.      �� 5/   
   $��1��6   $��1��6'   $��2��64   $��Center=�6E   $��5��6b   �� 51   
   -   5        $��X��51      $��2��6   $��1��6-   $��Right=�6:   $	��Top=�6V   $��20��6�   $��20��6�   �� 52   
   $ Vertical=�6   $��2��6,   $��2��6<   .+�53      �� $��
Отдел��6   $��4��6$   $��2��64   $
��Left=�6A   $��16(�6\   $��Italic$�6j   �� 54      $��
Отдел��6   
���   �6&   �� 55      -   5        $ nameTextBox��55   b   ��6   ��  �� ElementName$ DataGridDep�� �� Path$" SelectedItem.name_department�6b   �� 56      -   5        $��Принять��56      $��	0 10 0 10q�6?   57      58      59      