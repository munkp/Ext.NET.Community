/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.1.1 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class StringFilter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TStringFilter, TBuilder> : GridFilter.Builder<TStringFilter, TBuilder>
            where TStringFilter : StringFilter
            where TBuilder : Builder<TStringFilter, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TStringFilter component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Predefined filter value
			/// </summary>
            public virtual TBuilder Value(string value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : StringFilter.Builder<StringFilter, StringFilter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new StringFilter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(StringFilter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(StringFilter.Config config) : base(new StringFilter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(StringFilter component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public StringFilter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.StringFilter(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public StringFilter.Builder StringFilter()
        {
#if MVC
			return this.StringFilter(new StringFilter { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.StringFilter(new StringFilter());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public StringFilter.Builder StringFilter(StringFilter component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new StringFilter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public StringFilter.Builder StringFilter(StringFilter.Config config)
        {
#if MVC
			return new StringFilter.Builder(new StringFilter(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new StringFilter.Builder(new StringFilter(config));
#endif			
        }
    }
}