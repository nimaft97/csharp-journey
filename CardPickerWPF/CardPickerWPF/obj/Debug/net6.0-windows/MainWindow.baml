   M S B A M L   `   `   `  ����H  DCardPickerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CardPickerWPFCardPickerWPF  5   	       CardPickerWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CardPickerWPF     5   	     � Title$  Card Picker��5   	   $	��300��6   $	��789��6*   .��5	      � $	��800��6   $	��300��6    � RowDefinitions 5
   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��22* �6   �� 5      $	��25* �6   .+�5   
   �� $
��Left=�6   $��Center=�60   $��69,0,0,0q�6K   $��1��6]   .+�5      �� $��How many cards?��6   $��20(�6.   �� 5      -   5         ��Name$ numberOfCards��5       � Maximum$ 15Q�6,    � Minimum$ 1Q�69    �� AutoToolTipPlacement$ TopLeft=�6E    �� TickPlacement$ BottomRight=�6d    �� IsSnapToTickEnabled$
 True��6�   
���   �6�   5      �� 5   
   -   5        $��
Pick Cards��5      $
��Left=�6&   $��1��6A   $��Center=�6N   $��20(�6i   $��1��6w   $��	105,0,0,0q�6�   6�   �� 5   
   -   5        	 ��Name$	 listOfCards��5      $��2��6'   $��2��67   $��20(�6H   $��20,20,20,20q�6V   5      5      