   M S B A M L   `   `   `  ����G  CMD_AeroBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MD_AeroBoardMD_AeroBoard  5      $    MD_AeroBoard.ucSelectTimeLevel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MD_AeroBoard     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $
��Auto��5      $
��Auto��6-   
������    MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	Timelapse=�6&   $��32��5   2   $��32��5    2   $��Center=�5!   2   ���#176FA25"   2   �� 5#      $��18,0,0,0q�6   $��Center=�5$   (     MaterialDesignTextBlock#��[ 5%   (   $5��/Укажите интервал таймера:��5&   (   5'      �� 5)   
   -   5         ��Name$ slider��5)   .   $��1��6   $��0��6    �� Orientation$ 
Horizontal=�6>    � Minimum$ 1Q�6W   	 � Maximum$	 10000Q�6c      MaterialDesignDiscreteSlider#��[ 6s   
 � ToolTip$7
 1Интервал цикла выполнения:��6�    � Value$
 1000Q�6�   $	��100��6�   $��	0 10 10 0q�6�    �� TickFrequency$ 1Q�6�   $y�Visible=�5*   -   ���#176FA26B   56      57      