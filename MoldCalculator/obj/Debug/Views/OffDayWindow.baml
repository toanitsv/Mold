   M S B A M L   `   `   `  ����I  EMoldCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MoldCalculator.ViewsMoldCalculator.Views  5   	   '    !MoldCalculator.Views.OffDayWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MoldCalculator.Views     5   	   -   5        $��14(�5        � Title$  Mold - Off Day��5   	   $	��550��6    $
��1000��6-    � WindowStartupLocation$ CenterScreen=�6:    � 	Resources 5
         BackgroundSupplier �� 
StartPoint �� EndPoint � Offset � Color  MyButton �� 
TargetType �� Property	 �� Value��%�   &	        &	 �     7   �� 5   
   $	 0,1&�69   $	 1,0&�6J   ��5      � $ 0Q�6   $ DeepSkyBlue��6*   � 5      $	 1.5Q�6   $ Transparent��6,   5      �� 5   
   " ��6!   .�5      ��  � ��8	   6+   5      5      .��5      � $��5q�6   
 � ColumnDefinitions
 5   
   �� 5      �� 5      $��* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    
 5"      �� 5#      $
��Auto �6#   �� 5$      .+�5'      �� $	��ID:��6   $��Center=�6#   �� 5(      $��Select Date: ��6   $��1��6-   $��Center=�6:   �� 5)      -   5         ��Name$ btnApplyForAll��5)      $��2��6-   $��Apply For All Suppliers:��6:   $��0,20,5,0q�6]   ��5*      �� 5+       �� 
TargetType" ��6&   .R�5,      �� �� 5-      5.      5/      ��51      �� 52      " ��6   .�53      ��  � ��
	 ��  �67    �� Triggers 54      P� 55       P� Property �@J�IsMouseOver P� Value . . �56   "   ��  � ��
	 �  ��6?   �� 57   "    �@�Cursor$
	 Hand��6;   58      5:      5<      �� 5=      $��Description: ��6   $��3��6-   $��Bottom=�6:   �� 5?      -   5         ��Name$ txtID��5?      $��1��6%   $��Center=�65   {�.  ��6i   ��  �� ElementName$ dpSelectOffDay�� �� Path$ ActualHeight�(  "System.Windows.Controls.DatePicker  5@      -   5          Name$ dpSelectOffDay��5@      $��1��61   $��1��6>      SelectedDate$ 
04/14/1996X�6N   $��0,5,0,0q�6h   � 5A      -   5         �Name$ 
grSupplier��5A      $��2��6'   $��1��64   $��0,20,0,0q�6D   
 5B      �� 5C      �� 5D      �� 5E      5G      �� 5H      -   5        $ txtDescription��5H      $��3��6.   $��1��6<   $��Italic$�6L   $	��100��6_    �� TextWrapping$
 Wrap=�6o   �� 5I      -   5        $ btnSave��5I      $��4��6&   $��1��63   $��0,5,0,0q�6C   $	��100��6T   $��Right=�6`   $
��Save��6|   {�.  6�   5J      � 5K   
   $��1��6   $��5,0,0,0q�6   .+�5L      &   System.Windows.Controls.DataGrid  -   5          Name$ dgOffDay��5L         AutoGenerateColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserDeleteRows .    AlternatingRowBackground
 ����� �� AlternationCount$ 2��5N   8      HorizontalGridLinesBrush
 �����    VerticalGridLinesBrush
  �����! � ContextMenu! 5Q      �� 5R      .@�5S      m� -	   5        " m�Name$" miRemove��5S   #   $��Remove��65   6E   5T      #   Columns# 5V      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn$   Header$$ ID��6)   %   
IsReadOnly% . 1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 6G   �� *
OffDayID+  5X      $$ Off Day��6)   '   
Foreground
' ��  �% . & 6^   �� *	OffDate+( �� StringFormat$( 
MM/dd/yyyy��  5Y      $$ Description��6)   % . )   	FontStyle$) Italic$�6p   & 6P   �� *Description+6p     5Z      $$ Revise Time��6)   % . & 6P   �� *CreatedTime+$( 
MM/dd/yyyy��5\      5]      5^      5_      