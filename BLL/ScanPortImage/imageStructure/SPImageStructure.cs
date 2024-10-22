﻿using Maticsoft.Common.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage
{
    public abstract class SPImageStructure
    {
        /// <summary>
        /// 各种玩法的头部描述——在各个具体的类里面赋值
        /// </summary>
        protected String[] PTYPE_HEAD_DESC;

        /// <summary>
        /// 是否过关类型
        /// </summary>
        protected Boolean ISHAS_CLEARANCE_TYPE;

        /// <summary>
        /// 有效内容的高度——整个票面左边黑框的高度
        /// </summary>
        protected int HIGHLY_EFFECTIVE_CONTENT;

        /// <summary>
        /// 扫描单上的场次数量
        /// </summary>
        protected int SLIP_EVENT_NUMBER;

        /// <summary>
        /// 数据块
        /// </summary>
        protected List<ImageDataBlock> DATA_BLOCK_LIST = new List<ImageDataBlock>();

        /// <summary>
        /// 根据票面，得到所有要描的点
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public abstract List<Point> getDrawPoints(lottery_ticket lt);

        /// <summary>
        /// 获取数据内容的高度
        /// </summary>
        /// <returns></returns>
        public int getStructureHigh() {
            return this.HIGHLY_EFFECTIVE_CONTENT;
        }

        /// <summary>
        /// 取玩法头部描述字段
        /// </summary>
        /// <returns></returns>
        public String[] getPTypeHeadDesc() {
            return this.PTYPE_HEAD_DESC;
        }
    }
}
