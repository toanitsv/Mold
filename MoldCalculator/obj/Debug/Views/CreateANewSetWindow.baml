   M S B A M L   `   `   `  ����I  EMoldCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MoldCalculator.ViewsMoldCalculator.Views  5   	   .    (MoldCalculator.Views.CreateANewSetWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MoldCalculator.Views     5   	   -   5        $��14(�5        � Title$  Mold - Create A New Set��5   	   $	��500��6)   $	��800��69    � WindowStartupLocation$ CenterScreen=�6H   .��5	      � $��5q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� $��Select Order Information��6   $��5,8,5,5q�69   
�������.��5      �  5      �� 5      �� 5       5      �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   .+�5!      �� $��OutsoleCode: ��6    $��Center=�65   �� 5"      $��1��6    $��
Supplier: ��6-   $��Center=�6?   $��0,5,0,5q�6Z   �� 5#      $��2��6    $��Component: ��6-   $��Center=�6@   �� 5%      -   5         ��Name$ cbOutsoleCode��5%   /   $��1��6    �� DisplayMemberPath$ OutsoleCode��6F    �� SelectedValuePath$ OutsoleCode��6f   $��Center=�6�   ��6�   ��  �� ElementName$ dpRequestDate�� �� Path$ ActualHeight�6�   �� 5&      -   5        $ 
cbSupplier��5&   <   $��1��6   $��1��6/   $ SupplierName��6P   $ 
SupplierID��6q   $��0,5,0,5q�6�   $��Center=�6�   ��6�   �� $ dpRequestDate��$ ActualHeight�6  �� 5'      -   5        $ cbComponent��5'   <   $��1��6   $��2��6/   $ ComponentName��6Q   $ ComponentID��6s   $��Center=�6�   ��6�   �� $ dpRequestDate��$ ActualHeight�6�   5(      5)      �� 5*      $��1��6   $��10,0,0,0q�6'   $��Input Schedule��69   $��5,8,5,5q�6Q   
�������.��5+      �  5,      �� 5-      �� 5.      �� 5/      $
��auto �6+    51      �� 52      $
��auto �6(   �� 53      $
��auto �6(   �� 54      $
��auto �6(   .+�57      �� $��Quota (Pairs / Day): ��6!   $��Center=�6>   �� 58      $��1��6    $��Starting Date: ��6.   $��Center=�6E   $��0,5,0,5q�6`   �� 59      $��2��6    $��Requested Date: ��6.   $��Center=�6F   �� 5;      -   5        	 ��Name$	 txtQuota��5;   .   $��1��6   
�������$��Center=�6W   ��6y   �� $ dpRequestDate��$ ActualHeight�(  "System.Windows.Controls.DatePicker  5<      -   5        
  Name$
 dpStartDate��5<   !   $��1��66   $��1��6C      SelectedDate$ 
04/16/1996X�6S   $��0,5,0,5q�6m     5=      -   5        $
 dpRequestDate��5=   !   $��2��68   $��1��6E   $ 
11/16/2017X�6U   �� 5?      -   5         ��Name$ btnOptionRequestDate��5?      $��2��6;   $��2��6H   $��. . .��6X   $��2,0,0,0q�6�   � 5@      -	   5         �Name$ popOptionRequestDate��5@       � AllowsTransparency . $��Slide=�6T   $y�	Collapsed=�6�    � PlacementTarget 6k   �� $ btnOptionRequestDate��.��5A      �� 
�������
�������$��1,1,1,1q�6K   $	��150��6e   $��90��6t    �� Padding$ 2q�6�   ._�5B      �  5C   "   �� 5D   &   �� 5E   &   �� 5F   &   �� 5G   &   .+�5I   "   �� -
   5        $ btnClosePopUp��5I   )   $��X��6@   $��Right=�6L   $
��Bold"�6h   
���  ��$��0,0,0,5q�6�   $��3,0,3,0q�6�   �� 5J   "   -   5        $ btnOptioRequestDatePlus21��5J   )   
����  �$��1��6^   $��
= CSD + 21��6k   6�   �� 5K   "   -   5        $ btnOptioRequestDatePlus25��5K   )   
����  �$��2��6^   $��
= CSD + 25��6k   $��0,5,0,5q�6�   �� 5L   "   -   5        $ btnOptioRequestDatePlus30��5L   )   
����  �$��3��6^   $��
= CSD + 30��6k   6�   5M      5N      5O      5P      5Q      �� 5R      -   5        $ 
btnAddMold��5R   7   $��20,8,0,0q�6   $��2��6'   $��
+ Add Mold��6K    � ToolTip$ Click to Add��6y   ��5S      �� 5T       �� 
TargetType" ��6&   .R�5U      �� �� 5V      5W      5X      ��5Z      �� 5[       �� 
TargetType" ��6   .�5\      ��  �� Property � �� �� Value
 ��  �67    �� Triggers 5]      P� 5^       P� Property �@J�IsMouseOver P� Value . . �5_   "   ��  � ��
 �  ��6?   �� 5`   "    �@�Cursor$
 Hand��6;   �� 5a   "    � ��$
 Bold"�6?   5b      5d      5f      5g      � 5h   
   $��1��6   $��0,10,0,0q�6   .+�5i      &   System.Windows.Controls.DataGrid  -   5          Name$ dgCurrentMold��5i   (   $��0,5,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserDeleteRows .    AlternatingRowBackground
 ����� �� AlternationCount$ 2��5k   L       
IsReadOnly  . !   HorizontalGridLinesBrush
! �����"   VerticalGridLinesBrush
" �����#   Columns# 5m      0  *System.Windows.Controls.DataGridTextColumn  5n      ,  &System.Windows.Controls.DataGridColumn$   MinWidth$$ 80Q�6)   %   Header$% Size No��67   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 6H   �� *SizeNo+  5o      $$ 80Q�6)   $% Quantity��67   & 6I   �� *
Quantity+  5p      $$ 80Q�6)   $% Pairs��67   & 6F   �� *Pairs+' �� StringFormat$' {0:N0}��  5q      $$ 80Q�6)   $% Quota��67   & 6F   �� *Quota+  5r      $$ 80Q�6)   $% Starting Date��67   & 6N   �� *	StartDate+$' 
MM/dd/yyyy��  5s      $$ 80Q�6)   $% Working Days��67   & 6M   �� *
WorkingDay+  5t      -   5        colRequestedDate��$% Finished Date��5t   C   & 6Z   �� *
FinishDate+$' 
MM/dd/yyyy��(   	CellStyle( 5u      �� 5v      *  $System.Windows.Controls.DataGridCell"  6$   .�5w   "   ��  � �� 6?   �� *FinishDateBackground+�� 5x   "    � ��
 �   �6?   5y      5{        5|      $% Requested Delivery��6)   & 6E   �� *RequestDate+$' 
MM/dd/yyyy��5~      5      �� 5�   
   -   5        $ btnCalculate��5�   �   $��2��6   $��Right=�6^   $��0,5,0,0q�6z   $��	Calculate��6�   ��6   �� $ colRequestedDate��$ ActualWidth�6�   5�      5�      