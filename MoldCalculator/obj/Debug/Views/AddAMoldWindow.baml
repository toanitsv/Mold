   M S B A M L   `   `   `  ����I  EMoldCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MoldCalculator.ViewsMoldCalculator.Views  5   	   )    #MoldCalculator.Views.AddAMoldWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MoldCalculator.Views     5   	   $��14(�5        � Title$  
Add a Mold��5   	   $
��Auto��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[    � SizeToContent$ Height=�6q   .��5	      � $��5q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��	Quantity:��6   $��0,5,0,0q�6%   �� 5   
   -   5         ��Name$ txtQuantityMold��5   "   $��1��6   6;   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5         ��Name$ btnAddSizeNo��5   &   $��0,5,0,0q�6   $��+ SizeNo��6<   ��5      �� 5      	 �� 
TargetType"	 ��6&   .R�5      �� �� 5      5      5       ��5"      �� 5#      
 �� 
TargetType"
 ��6   .�5$      ��  �� Property � �� �� Value
 ��  �67    �� Triggers 5%      P� 5&       P� Property �@J�IsMouseOver P� Value . . �5'   "   ��  � ��
 �  ��6?   �� 5(   "    � ��$
 Bold"�6?   �� 5)   "    �@�Cursor$
 Hand��6;   5*      5,      5.      �� 5/      -   5         ��Name$ txtPositionPopUp��5/      $��5,0,0,0q�62   � 50      -   5         �Name$ popAddSizeNo��50       � AllowsTransparency . $��Slide=�6D   $y�	Collapsed=�6�    � PlacementTarget 6[   ��  �� ElementName$ txtPositionPopUp��.��51      �� 
�������$	��150��6/   $��90��6>    �� Padding$ 2q�6M   ._�52      �  53      �� 54      $
��auto �6,   �� 55      $��* �6,   .+�57      �� -   5        $ btnClosePopUp��57   !   $��0,0,0,5q�68   $��3,0,3,0q�6I   $��X��6[   $
��Bold"�6g   
���  ��$��1��6�   $��Right=�6�   58      �� 59      $��1��6'   $��Hidden=�64   $
��Auto=�6[   .��5:      �� -   5         ��Name$ stkSizeRunList��5:   )   $ Vertical=�6A   5;      5<      5=      5>      5?      5@      �� 5B   
   -   5        $ 	txtSizeNo��5B      $��1��6'   $��1��64   $��Italic$�6D   $
��Bold"�6W   $��Bottom=�6i   $
��Wrap=�6�   �� 5D   
   $��Total Pairs:��6   $��2��6(   $��0,5,0,0q�65   �� 5E   
   -   5        $ txtPairs��5E   B   $��2��6   $��1��6!   $��0,5,0,0q�61   6B   �� 5G   
   $��Working Days:   ��6   $��3��6,   $��0,5,0,0q�69   �� 5H   
   -	   5        $ txtWorkingDay��5H   B   $��3��6   $��0,5,0,0q�6!   $��1��62   6B   �� 5J   
   $��Finish Date:��6   $��4��6(   $��0,5,0,0q�65   $��Center=�6F   (  "System.Windows.Controls.DatePicker  5K   
   -
   5          Name$ dpFinishDate��5K   C   $��4��6   $��0,5,0,0q�6"   $��1��63      SelectedDate$ 
04/14/1996X�6Y   �� 5M   
   -   5        $ btnAdd��5M      {�.  $	��Add��63   $��5��6A   $��1��6N   $��0,10,0,0q�6^   6p   5O      5P      