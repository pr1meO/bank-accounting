   M S B A M L   `   `   `  ����  BankAccouting%    BankAccouting.Pages.AccountPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $	��395��5      $	��630��5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��30 �6   �� 5      $��10 �6   �� 5      $��1 �6   �� 5      $��10 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $��60 �6   �� 5      $��40 �6   �� 5      $��10 �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   $��0��5      $��
Счета��5      $��28(�5      $��Center=�5      $��Calibri)�5      $��Medium"�5      ���#1215185       �� 5#   
   -   5        $��1��5#      $��0��5$      $��4��5%         	addButton#��[  5&      .��5(      ��  �� Orientation$ 
Horizontal=�6   .+�5)      �� $��Добавить��6   5*      5,      �� 5/   
   $��0��6   $��2��50      $��5��51       �� CornerRadius$ 1��52      ���#d9d9d953      &   System.Windows.Controls.DataGrid  55   
   -   5          Name$ 	accountDG��55      $��0��56      $��4��57      $��5��58        rowStyle   RowStyle# [ 59        columnHeader   ColumnHeaderStyle# [ 5:        	cellStyle   	CellStyle# [ 5;       	 table#��[ 5<         Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn	   Header$	 #��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5A   %   �� *Id+  5B      $	 Клиент��6%   
 5C   %   �� *
ClientId+  5D      $	 Баланс��6%   
 5E   %   �� *	Balance+  5F      $	 Тип счета��6%   
 5G   %   �� *TypeAccount+ � ContextMenu 5K      �� 5M      .@�5N      m� -   5        $��Изменить��5N      5O      m� 5P      -   5        $��Удалить��5P      5Q      5R      5V      5X      5Z      