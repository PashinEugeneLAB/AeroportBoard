   M S B A M L   `   `   `  ����G  CMD_AeroBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MD_AeroBoardMD_AeroBoard  5      "    MD_AeroBoard.ucDepartureCard   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MD_AeroBoard     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $
��Auto��5      $
��Auto��6-   ���#176FA2
������    MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��0��6&   $��0��63      Kind$ FlightTakeoff=�6C   $��32��6X   $��32��6d   $��Center=�6o   ���#FFFFFF$��18q�6�   �� 5       -   5        $��
FlightType��5    5   $��0��6   $��1��6%   $��18,0,0,0q�6G   $��Center=�6Y     MaterialDesignTextBlock#��[ 6t   $��Тип самолёта��6�   
�������6�   �� 5!      -   5        $��FlightFromTo��5!   5   $��0��6   $��2��6%   $��18,0,0,0q�6I   $��Center=�6[   #��[ 6v   $��Куда��6�   
�������6�   �� 5"      -   5        $��
FlightTime��5"   5   $��0��6   $��3��6%   $��18,0,0,0q�6G   $��Center=�6Y   #��[ 6t   $��
Время��6�   
�������6�   �� 5#      -   5        $��FlightStatus��5#   5   $��0��6   $��4��6%   $��	18,0,18,0q�6I   $��Center=�6\   #��[ 6w   $��Состояние��6�   
�������6�   5$      5(      5)      