   M S B A M L   `   `   `  ����D  @WPF_Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPF_Admin.ViewModelsWPF_Admin.ViewModels  5      "    WPF_Admin.Views.EditPostPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1vm"clr-namespace:WPF_Admin.ViewModels     5        N� Title$  EditPostPage��5	       � DataContext 5      ,  &WPF_Admin.ViewModels.EditPostViewModel  5   
   .��5      � ���	#FF272727 � RowDefinitions 5   
   �� 5      $	��31* �6   �� 5      $	��33* �6   �� 5      $
��325* �6   �� 5      $	��28* �6   �� 5      $	��34* �6    � ColumnDefinitions 5   
   �� 5      $
��223* �6   �� 5      $
��245* �6   �� 5      $
��186* �6   �� 5      $
��140* �6   .+�5   
   �� $��0��6   $��0��6    $��Your newsposts��6-   $��Center=�6F   $��14(�6j   $
��Bold"�6x   
�������6�   �� 5   
   $��0��6`   $��1��6p   $��3q�6}   $��4��6�   ��6   �� *authorPosts+ �� SelectedItem 66   �� *SelectedNewsPost+��5       �� 5!      .R�5"      �� .+�5#      �� $��12(�6<   $
��Wrap=�6J   ��6$   �� *Header+6J   5$      5%      5'      �� 5)   
   $��1��6   $��0��6    $��Editor��6-   $��Center=�6>   $��14(�6b   $
��Bold"�6p   
�������$��2��6�   �� 5*   
    �� TextWrapping$
 Wrap=�6`   $��1��6t   $��1��6�   $��3q�6�   $��3��6�   ��6   �� *SelectedNewsPost.Header+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5+   
   $
 Wrap=�6a   $��1��6u   $��2��6�   $��3q�6�   $��3��6�   ��6   �� *SelectedNewsPost.Content+$ PropertyChanged=�6�   �� 5,   
   $
 Wrap=�6^   $��1��6r   $��3��6�   $��2��6�   $��3q�6�   ��6   �� *SelectedNewsPost.Tags+$ PropertyChanged=�6�   �� 5-   
   $
��Edit��62   $��1��6A   $��4��6Q   $��3q�6^   $��2��6i   ��6   �� *EditNewsPost+6i   �� 5.   
   $��3��68   $��4��6H   $��3q�6U   $��Cancel��6`   ��6   �� *BackToPreviousPage+6`   5/      50      