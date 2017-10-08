using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace analizadorLexico
{
    class analizador 
    {
        #region variables-lexico
        public int[,] M = {
            {2,1,2,1,3,500,107,108,109,110,111,500,9,11,14,15,13,16,17,18,122,123,124,125,126,128,127,19, 0, 0, 0, 500},
            {2,1,2,1,2,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100},
            {2,2,2,2,2,101,101,2,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101},
            {102,102,102,102,3,4,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102},
            {501,501,501,501,5, 501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501,501},
            {103,103,6,6,5,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103,103 },
            {502,502,502,502,8,502,7,7,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502,502},
            {503 ,503,503,503,8,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503,503},
            {104,104,104,104,8,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104},
            {10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,504,10,10,10,10,10,10},
            {505, 505,505,505,505,505,505,505,505,505,505,505,105,505,505,505,505,505,505,505,505,505,505,505,505,505,505,505,505,505,505,505},
            {11,11,11,11,11,11,11,11,11,11,11,11,11,12,11,11, 11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11},
            {106,106,106,106,106,106,106,106,106,106,106,106,106,11,106,106,106,106,106,106,106,106,106,106,106,106,106,106,106,106,106,106},
            {112,112,112,112,112,112,112,112,112,112,112,112,112,112,112,112,113,112,112,112,112,112,112,112,112,112,112,112,112,112,112,112},
            {114,114,114,114,114,114,114,114,114,114,114,114,114,114,114,114,115,114,114,114,114,114,114,114,114,114,114,114,114,114,114,114},
            {116,116,116,116,116,116,116,116,116,116,116,116,116,116,116,116,117,116,116,116,116,116,116,116,116,116,116,116,116,116,116,116},
            {119,119,119,119,119,119,119,119,119,119,119,119,119,119,119,119,118,119,119,119,119,119,119,119,119,119,119,119,119,119,119,119},
            {506,506,506,506,506,506,506,506,506,506,506,506,506,506,506,506,506,506,120,506,506,506,506,506,506,506,506,506,506,506,506,506},
            {507,507,507,507,507,507,507,507,507,507,507,507,507,507,507,507,507,507,507,121,507,507,507,507,507,507,507,507,507,507,507,507},
            {19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,129,19,19}
            };

        public string[] palabrasReservadas = { "procedure", "is" ,"begin", "end", "declare" , "constant"
        ,"integer","float","char","string","if","then","elsif","else","endif","while","loop","endloop","do","whiledo","enddo"
        ,"read","write"};
        #endregion variables-lexico
        // public static int[] inicial = { 153, 1 };
        #region variables-sintactico


        int t;
        //Stack<int> pila = new Stack<int>(/*inicial*/);



        public int[,] predictiva =
        {
{1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000},
{1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,3,1001,2,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001,1001},
{4,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002,1002},
{5,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003,1003},
{1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,7,6,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004,1004},
{1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,8,1005,1005,9,9,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005,1005},
{1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,10,1006,1006,11,11,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006,1006},
{1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,13,12,12,12,12,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007,1007},
{14,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,15,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008,1008},
{1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,16,17,18,19,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009,1009},
{1010,20,21,22,23,24,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010,1010},
{25,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,1011,31,1011,1011,1011,1011,1011,1011,26,1011,31,31,31,27,1011,31,28,31,1011,29,30,1011},
{1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,32,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012,1012},
{33,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,1013,34,1013,1013,1013,1013,1013,1013,33,1013,34,34,34,33,1013,34,33,34,1013,33,33,1013},
{35,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014,1014},
{36,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015,1015},
{1016,1016,1016,1016,1016,1016,38,38,38,38,38,38,38,38,38,38,38,38,1016,38,38,1016,38,37,38,38,1016,38,1016,1016,1016,1016,1016,1016,1016,1016,1016,1016,1016,1016,38,1016,1016,1016,1016,38,1016,1016,1016,38,1016,1016,1016},
{39,39,39,39,39,39,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,39,1017,1017,39,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017,1017},
{1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,41,1018,1018,40,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018,1018},
{42,42,42,42,42,42,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,42,1019,1019,42,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019,1019},
{45,45,45,45,45,45,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,45,1020,1020,45,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020,1020},
{1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,43,1021,44,1021,44,44,1021,44,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,1021,44,1021,1021,1021,1021,44,1021,1021,1021,44,1021,1021,1021},
{48,48,48,48,48,48,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,48,1022,1022,48,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022,1022},
{1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,46,47,1023,47,1023,47,47,1023,47,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,1023,47,1023,1023,1023,1023,47,1023,1023,1023,47,1023,1023,1023},
{51,51,51,51,51,51,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,51,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024},
{50,50,50,50,50,50,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,49,1025,1025,50,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,1025,50,1025,1025,1025,1025,50,1025,1025,1025,50,1025,1025,1025},
{54,54,54,54,54,54,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,54,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026,1026},
{1027,1027,1027,1027,1027,1027,1027,1027,1027,1027,1027,1027,52,52,52,52,52,52,1027,53,53,1027,53,1027,53,53,1027,53,1027,1027,1027,1027,1027,1027,1027,1027,1027,1027,1027,1027,53,1027,1027,1027,1027,53,1027,1027,1027,53,1027,1027,1027},
{1028,1028,1028,1028,1028,1028,55,56,1028,1028,1028,1028,57,57,57,57,57,57,1028,57,57,108,57,1028,57,57,1028,57,1028,1028,1028,1028,1028,1028,1028,1028,1028,1028,1028,1028,57,1028,1028,1028,1028,57,1028,1028,1028,57,1028,1028,1028},
{1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,66,68,69,70,71,67,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029,1029},
{58,58,58,58,58,58,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,58,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030,1030},
{1031,1031,1031,1031,1031,1031,62,62,59,60,61,1031,62,62,62,62,62,62,1031,62,62,1031,62,1031,62,62,1031,62,1031,1031,1031,1031,1031,1031,1031,1031,1031,1031,1031,1031,62,1031,1031,1031,1031,62,1031,1031,1031,62,1031,1031,1031},
{63,64,65,72,73,74,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,75,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032,1032},
{1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,76,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033,1033},
{1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,1034,77,78,78,1034,1034,1034,1034,1034,1034,1034,1034,1034},
{1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,1035,79,80,1035,1035,1035,1035,1035,1035,1035,1035,1035},
{1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,1036,81,1036,1036,1036,1036,1036,1036,1036,1036},
{1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,1037,82,1037,1037,1037,1037,1037},
{1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,1038,83,1038,1038},
{84,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039,1039},
{1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,86,1040,1040,1040,1040,85,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040,1040},
{1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,1041,87,1041},
{88,88,88,88,88,88,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,88,1042,1042,88,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042,1042},
{1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,90,1043,1043,1043,1043,89,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043,1043}
        };

        public int[][] producciones =
            {
 new int[]{130,101,131,2,132,12,133},
new int[]{134,3},
new int[]{-1},
new int[]{4,5,127,8,126,9},
new int[]{101,10000,6},
new int[]{128,4,5},
new int[]{-1},
new int[]{7},
new int[]{-1},
new int[]{124,102,125,7},
new int[]{-1},
new int[]{10,10002},
new int[]{135,10003,10,112,11 },
new int[]{3},
new int[]{-1},
new int[]{136,10001},
new int[]{137,10001},
new int[]{138,10001},
new int[]{139,10001},
new int[]{10004,102},
new int[]{10004,103},
new int[]{10004,104},
new int[]{10004,105},
new int[]{10004,106},
new int[]{15,13},
new int[]{34,13},
new int[]{37,13},
new int[]{38,13},
new int[]{39,13},
new int[]{42,13},
new int[]{-1},
new int[]{126,14},
new int[]{12},
new int[]{-1},
new int[]{16,112,20},
new int[]{101,17},
new int[]{124,18,125},
new int[]{-1},
new int[]{20,19},
new int[]{128,18},
new int[]{-1},
new int[]{21,22},
new int[]{121,10005,20},
new int[]{-1},
new int[]{23,24},
new int[]{120,10005,21},
new int[]{-1},
new int[]{26,25},
new int[]{119,10005},
new int[]{-1},
new int[]{27,28},
new int[]{30,27},
new int[]{-1},
new int[]{31,29},
new int[]{107, 10005, 27},
new int[]{108, 10005, 27},
new int[]{-1},
new int[]{33,32},
new int[]{109, 10005, 31},
new int[]{110, 10005, 31},
new int[]{111, 10005, 31},
new int[]{-1},
new int[]{16},
new int[]{102},
new int[]{103},
new int[]{113,10005},
new int[]{118,10005},
new int[]{114,10005},
new int[]{115,10005},
new int[]{116,10005},
new int[]{117,10005},
new int[]{104},
new int[]{105},
new int[]{106},
new int[]{122,20,123},
new int[]{140,20,141,12,35,36,144},
new int[]{142,20,141,12,35},
new int[]{-1},
new int[]{143,12},
new int[]{-1},
new int[]{145,20,146,12,147},
new int[]{148,12,149,20,150},
new int[]{151,122,40,123},
new int[]{101,41},
new int[]{128,40},
new int[]{-1},
new int[]{152,122,43,123},
new int[]{20,44},
new int[]{128,43},
new int[]{-1}
    };

        #endregion variables-sintactico

        #region variables-semantico
        public Stack<int> operadores,tipos, operandos, avail, saltos = new Stack<int>();
        public List<Cuadruplo> cuadruplos = new List<Cuadruplo>();
        public List<TabSimbol> tabla_simbolos = new List<TabSimbol>();
        public List<TabConst> tabla_constantes = new List<TabConst>();

        #endregion variables-semantico

        int edo, col, fila, inicio, fin, contar;
        public void analiza(TextBox txt, TextBox l)
        {
            //  txt.Text.Replace("\n","");
            //int edo, col, fila, inicio, fin, contar;
            //contar = 0;
            char car;
            //inicio = 0;

            //fin = 0;
            //while (contar < txt.Text.Length)
            //{
            edo = 0;
            while (edo <= 19)
            {       //mientras se esté en los estados de transicion
                fila = edo;
                car = leer_caracter(contar, txt);
                contar++;
                //if (car == '\r')
                //    contar += 2;
                //else
                col = relaciona(car);   //relaciona el caracter con la columna que le corresponde
                edo = M[edo, col];

                fin = contar - 1;

            }
            #region Cambios
            if (edo >= 100 && edo <= 129)
            {
                //txt.Text += edo + " ";
                //Console.WriteLine(edo);
                token(edo, l, txt, inicio, fin);     //es un estado de aceptación    
                contar -= 1;
                #region cambios18May
                //cambios 17 / 05 / 2017
                if (edo == 112 | edo == 119 | edo == 114 | edo == 116)
                {

                }
                else if (edo >= 107 && edo <= 128 && edo != 112 && edo != 119 | edo == 120 | edo == 121 || edo == 105)
                {
                    #endregion cambios18May
                    contar += 1;
                    fin = contar;
                    //contar += 1;

                }

            }
            #endregion cambios
            else
                error(edo, l);     //manda llamar a la tabla de errores para saber porque falló
            inicio = fin;
            fin = 0;

            //}

        }



        char leer_caracter(int c, TextBox cadena)
        {
            char ch = ' ';
            string str = cadena.Text;
            if (c < str.Length)
            {

                ch = str[c];
            }
            return ch;
        }
        string var;
        int relaciona(int c)
        {
            int col = 31;
            if (c >= 'A' && c <= 'Z' && c != 'E')
                col = 0;   //regresa columna de L
            else
            if (c >= 'a' && c <= 'z' && c != 'e')
                col = 1;   //regresa columna l
            else
                if (c >= '0' && c <= '9')
                col = 4;
            else
                switch (c)
                {
                    case 'E':
                        col = 2;
                        break;
                    case 'e':
                        col = 3;
                        break;
                    case '.':
                        col = 5;
                        break;
                    case '+':
                        col = 6;
                        break;
                    case '-':
                        col = 7;
                        break;
                    case '*':
                        col = 8;
                        break;
                    case '/':
                        col = 9;
                        break;
                    case '%':
                        col = 10;
                        break;
                    case '_':
                        col = 11;
                        break;
                    case 39:
                        col = 12;
                        break;
                    case '"':
                        col = 13;
                        break;
                    case '<':
                        col = 14;
                        break;
                    case '>':
                        col = 15;
                        break;
                    case '=':
                        col = 16;
                        break;
                    case '!':
                        col = 17;
                        break;
                    case '&':
                        col = 18;
                        break;
                    case '|':
                        col = 19;
                        break;
                    case '(':
                        col = 20;
                        break;
                    case ')':
                        col = 21;
                        break;
                    case '[':
                        col = 22;
                        break;
                    case ']':
                        col = 23;
                        break;
                    case ';':
                        col = 24;
                        break;
                    case ',':
                        col = 25;
                        break;
                    case ':':
                        col = 26;
                        break;
                    case '#':
                        col = 27;
                        break;
                    case ' ':
                        col = 28;
                        break;
                    case '\r':
                        col = 29;
                        break;
                    case '\t':
                        col = 30;
                        break;
                    //cambios 20 mayo 2017
                    case '\n':
                        col = 29;
                        break;

                }
            return col;
        }
        //txt = codigo a analizar
        // l = consola
        public void token(int e, TextBox l, TextBox txt, int i, int f)
        {
            //asigna el token
            t = e;
            switch (e)
            {
                case 100:
                    {
                        if (reservadas(txt, i, f))
                        {
                            l.AppendText("palabra reservada \n");
                            //asigna el identificador numerico de la palabra reservada
                            t = clave;
                        }
                        else
                        {
                            // l.AppendText("identificador \n");
                            var = txt.Text.Substring(i, f - i).Trim();
                            l.AppendText("identificador :" +var + "\n");
                            
                            //asigna 101
                            t = e + 1;
                        }
                        break;
                    }
                case 101:
                   var = txt.Text.Substring(i, f - i).Trim();
                    l.AppendText("identificador "+var+"\n");
                    break;
                case 102:
                    l.AppendText("constante entera \n");
                    break;
                case 103:
                    l.AppendText("constante real \n");
                    break;
                case 104:
                    l.AppendText("constante notacion cientifica \n");
                    break;
                case 105:
                    l.AppendText("constante caracter \n");
                    break;
                case 106:
                    l.AppendText("constante string \n");
                    break;
                case 107:
                    l.AppendText("Mas ( + ) \n");
                    break;
                case 108:
                    l.AppendText("Menos ( - ) \n");
                    break;
                case 109:
                    l.AppendText("Por ( * ) \n");
                    break;
                case 110:
                    l.AppendText("Entre ( / ) \n");
                    break;
                #region cambio modulo
                case 111:
                    l.AppendText(" Modulo ( % ) \n");
                    #endregion cambio
                    break;
                case 112:
                    l.AppendText("Asignación ( = ) \n");
                    break;
                case 113:
                    l.AppendText("Igual ( == ) \n");
                    break;
                case 114:
                    l.AppendText("Menor que( < ) \n");
                    break;
                case 115:
                    l.AppendText("Menor o igual que ( <= ) \n");
                    break;
                case 116:
                    l.AppendText("Mayor que ( > ) \n");
                    break;
                case 117:
                    l.AppendText("Mayor o igual que ( >= ) \n");
                    break;
                case 118:
                    l.AppendText("Diferente de ( != ) \n");
                    break;
                case 119:
                    l.AppendText("Not ( ! ) \n");
                    break;
                case 120:
                    l.AppendText("And  ( && ) \n");
                    break;
                case 121:
                    l.AppendText("Or ( || ) \n");
                    break;
                case 122:
                    l.AppendText("Parentesis izquierdo ( \n");
                    break;
                case 123:
                    l.AppendText("Parentesis derecho ) \n");
                    break;
                case 124:
                    l.AppendText("Corchete izquierdo [ \n");
                    break;
                case 125:
                    l.AppendText("Corchete derecho ] \n");
                    break;
                case 126:
                    l.AppendText("Punto y coma ( ; ) \n");
                    break;
                case 127:
                    l.AppendText("Dos puntos ( : ) \n");
                    break;
                case 128:
                    l.AppendText("Coma ( , ) \n");
                    break;
                case 129:
                    l.AppendText("Comentario \n");
                    break;
            }

        }

        public void error(int e, TextBox l)
        {
            switch (e)
            {
                case 500:
                    l.AppendText("500: caracter desconocido para el lenguaje \n");
                    break;
                case 501:
                    l.AppendText("501: Esperaba digito despues de un punto\n");
                    break;
                case 502:
                    l.AppendText("502: esperaba digito, +, -, despues de E/e \n");
                    break;
                case 503:
                    l.AppendText("503: se esperaba digito despues de + o - \n");
                    break;
                case 504:
                    l.AppendText("504: esperaba caracter despues de la comilla \n");
                    break;
                case 505:
                    l.AppendText("505: esperaba comilla para cerrar la constante caracter \n");
                    break;
                case 506:
                    l.AppendText("506: esperaba un & \n");
                    break;
                case 507:
                    l.AppendText("507: esperaba un | \n");
                    break;
            }

        }
        //variable para enlazar cada palabra reservada con el sintactico
        public int clave = 0;
        public bool reservadas(TextBox txt, int s, int f)
        {
            //int indice = 0;
            if (f > txt.Text.Length)
            {
                f = f - 1;
            }
            string buscar = txt.Text.Substring(s, f - s);
            buscar = buscar.Trim();
            bool bandera = false;
            bandera = palabrasReservadas.Contains(buscar);
            //Obtiene el indice de la palabra reservada 
            clave = Array.IndexOf(palabrasReservadas, buscar) + 130;
            return bandera;

        }



        public int aSint(TextBox tx1, TextBox tx2)
        {
            Console.WriteLine("-------------INICIO----------------");
            t = 0;
            edo = 0;
            col = 0;
            fila = 0;
            inicio = 0;
            fin = 0;
            contar = 0;
            int filap = 0, prediccion = 0;
            Stack<int> pila = new Stack<int>();
            pila.Push(153);
            pila.Push(1);
            while (pila.Count() > 1)
            {
                analiza(tx1, tx2);
                Console.WriteLine("Tope: " + pila.Peek() + " T: " + t);
                //Si el token es un comentario brinca el ciclo para obtener el siguiente token
                if (t == 129)
                {
                    continue;
                }
                //mientrasa el tope de pila es una fila de la predictivoa
                while (pila.Peek() < 50 || pila.Peek()>=10000)
                {
                    if (pila.Peek() >= 10000)
                    {
                        acciones(pila.Pop());

                    }
                    if (pila.Peek() > -1 && pila.Peek()<50)
                    {
                        
                        filap = predictiva[pila.Peek() - 1, t - 101] - 1;
                        Console.WriteLine("Producción: " + (filap + 1));
                        //si la posicion en la matriz devuelve un numero de producción
                        if (filap < 100 && filap > -1) {
                            //saca el tope de pila que mandó a la producción
                            Console.WriteLine("Sale: " + pila.Pop());
                            Console.Write("Pila: ");
                            //mete la producción correspondiente a la pila
                            for (int i = producciones[filap].Length - 1; i >= 0; i--)
                            {
                                pila.Push(producciones[filap][i]);
                            }
                          
                            foreach (int i in pila)
                            {
                                Console.Write(" " + i + " ");
                            }
                            Console.WriteLine("");
                        }
                        //si la posición en la matriz devuelve un error

                        else
                        {

                            Console.WriteLine("Error: " + filap + " con tope: " + pila.Peek() + " y token: " + t);
                            errorS(tx2, (filap + 1));
                            return -1;
                        }
                    }
                    //si es vacio (-1) lo saca de la pila
                    else if (pila.Peek() == -1)
                    {
                        Console.WriteLine("Sale: " + pila.Pop());
                    }
                    

                }

                prediccion = pila.Peek();
                Console.WriteLine("Prediccion: " + prediccion + "   token: " + t);
                //si la predicción es correcta
                if (prediccion == t)
                {
                    if (pila.Peek() >= 10000)
                    {
                        acciones(pila.Pop());

                    }
                    //saca ese elemento de la pila
                    Console.WriteLine("Prediccion correcta");
                    Console.WriteLine("Sale: " + pila.Pop());
                }
                // si no es correcta
                else if (prediccion != t)
                {
                   
                    //manda error
                    Console.WriteLine("Error: se esperaba token " + prediccion);
                    errorS(tx2, prediccion);
                    return -1;
                }
                //si se llegó al final del archivo y aún hay elementos en la pila
                if (pila.Count > 1 && contar == tx1.Text.Length)
                {
                    //error
                    errorS(tx2, pila.Peek());
                    //si el tope de pila es una fila de predictiva
                    if (pila.Peek() < 50)
                    {
                        errorS(tx2, pila.Peek() + 999);
                    }
                    return -1;
                }
            }



            Console.WriteLine("-------------------FIN--------------------------");
            Console.WriteLine("Contar: " + contar + " Fin: " + fin + " length: " + tx1.Text.Length);
            //si ya se terminó de analizar pero aún no se llegó al final del archivo
            if (contar < tx1.Text.Length)
            {
                tx2.Text = "Error: Sobran tokens:\r\n" + tx1.Text.Substring(contar);
            }
            //si todo fue correcto
            else
            {
                tx2.AppendText( "Sintáxis correcta");
                Console.WriteLine("Tabla de simbolos");
                foreach (TabSimbol p in tabla_simbolos)
                {
                    Console.WriteLine("Dir: {0} Descripcion: {1} Tipo: {2} TipoVar:{3}",p.direccion,p.descripcion, p.tipo,p.var);
                }
                Console.WriteLine("tabla de constantes");
                foreach (TabConst c in tabla_constantes)
                {
                    Console.WriteLine("Dir: {0} Tipo: {1} Valor: {2}", c.dir, c.tipo, c.valor);
                }
                Console.WriteLine("Cuadruplos");
                foreach (Cuadruplo c in cuadruplos)
                {
                    Console.WriteLine("Codop: {0}| Op1: {1} |Op2: {2}| Res:{3}", c.codop, c.op1, c.op2,c.res);
                }
                tabla_simbolos.Clear();
                tabla_constantes.Clear();
                cuadruplos.Clear();
                dr = 10000;
                dir = 20000;
            }
            return 0;
        }


        public void errorS(TextBox tx, int e)
        {

            switch (e)
            {
                case 101:
                    tx.Text = "Error de sintaxis: se esperaba un identificador";
                    break;
                case 102:
                    tx.Text = "Error de sintaxis: se esperaba una constante entera";
                    break;
                case 103:
                    tx.Text = "Error de sintaxis: se esperaba una constante real";
                    break;
                case 104:
                    tx.Text = "Error de sintaxis: se esperaba una constante en notación científica";
                    break;
                case 105:
                    tx.Text = "Error de sintaxis: se esperaba una constante caracter";
                    break;
                case 106:
                    tx.Text = "Error de sintaxis: se esperaba una constante string";
                    break;
                case 107:
                    tx.Text = "Error de sintaxis: se esperaba +";
                    break;
                case 108:
                    tx.Text = "Error de sintaxis: se esperaba -";
                    break;
                case 109:
                    tx.Text = "Error de sintaxis: se esperaba *";
                    break;
                case 110:
                    tx.Text = "Error de sintaxis: se esperaba /";
                    break;
                case 111:
                    tx.Text = "Error de sintaxis: se esperaba %";
                    break;
                case 112:
                    tx.Text = "Error de sintaxis: se esperaba =";
                    break;
                case 113:
                    tx.Text = "Error de sintaxis: se esperaba ==";
                    break;
                case 114:
                    tx.Text = "Error de sintaxis: se esperaba <";
                    break;
                case 115:
                    tx.Text = "Error de sintaxis: se esperaba <=";
                    break;
                case 116:
                    tx.Text = "Error de sintaxis: se esperaba >";
                    break;
                case 117:
                    tx.Text = "Error de sintaxis: se esperaba >=";
                    break;
                case 118:
                    tx.Text = "Error de sintaxis: se esperaba !=";
                    break;
                case 119:
                    tx.Text = "Error de sintaxis: se esperaba !";
                    break;
                case 120:
                    tx.Text = "Error de sintaxis: se esperaba &&";
                    break;
                case 121:
                    tx.Text = "Error de sintaxis: se esperaba ||";
                    break;
                case 122:
                    tx.Text = "Error de sintaxis: se esperaba (";
                    break;
                case 123:
                    tx.Text = "Error de sintaxis: se esperaba )";
                    break;
                case 124:
                    tx.Text = "Error de sintaxis: se esperaba [";
                    break;
                case 125:
                    tx.Text = "Error de sintaxis: se esperaba ]";
                    break;
                case 126:
                    tx.Text = "Error de sintaxis: se esperaba ;";
                    break;
                case 127:
                    tx.Text = "Error de sintaxis: se esperaba :";
                    break;
                case 128:
                    tx.Text = "Error de sintaxis: se esperaba ,";
                    break;
                case 130:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'procedure' ";
                    break;
                case 131:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'is' ";
                    break;
                case 132:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'begin' ";
                    break;
                case 133:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'end' ";
                    break;
                case 134:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'declare' ";
                    break;
                case 135:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'constant' ";
                    break;
                case 136:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'integer' ";
                    break;
                case 137:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'float' ";
                    break;
                case 138:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'char' ";
                    break;
                case 139:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'string' ";
                    break;
                case 140:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'if' ";
                    break;
                case 141:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'then' ";
                    break;
                case 142:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'elsif' ";
                    break;
                case 143:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'else' ";
                    break;
                case 144:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'endif' ";
                    break;
                case 145:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'while' ";
                    break;
                case 146:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'loop' ";
                    break;
                case 147:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'endloop' ";
                    break;
                case 148:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'do' ";
                    break;
                case 149:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'whiledo' ";
                    break;
                case 150:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'enddo' ";
                    break;
                case 151:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'read' ";
                    break;
                case 152:
                    tx.Text = "Error de sintaxis: se esperaba palabra reservada 'write' ";
                    break;
                case 1000:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'procedure'";
                    break;
                case 1001:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'begin' o 'declare'";
                    break;
                case 1002:
                    tx.Text = "Error " + e + ": se esperaba identificador";
                    break;
                case 1003:
                    tx.Text = "Error " + e + ": se esperaba  identificador";
                    break;
                case 1004:
                    tx.Text = "Error " + e + ": se esperaba : o ,";
                    break;
                case 1005:
                    tx.Text = "Error " + e + ": se esperaba [ o : o ,";
                    break;
                case 1006:
                    tx.Text = "Error " + e + ": se esperaba [ o : o ,";
                    break;
                case 1007:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'integer' o 'float' o 'char' o 'string'\r\n o 'constant'";
                    break;
                case 1008:
                    tx.Text = "Error " + e + ": se esperaba identificador o palabra reservada 'begin'";
                    break;
                case 1009:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'integer' o 'float' o 'char' o 'string'";
                    break;
                case 1010:
                    tx.Text = "Error " + e + ": se esperaba constante entera, o constante real, o constante en notación científica\r\n"
                      + "o constante caracter, o constante string  ";
                    break;
                case 1011:
                    tx.Text = "Error " + e + ": se esperaba identificador o palabra reservada 'if', o' 'while' o 'do', o 'read' o 'write'\r\n"
                        + "o 'end', o 'endif', o 'endloop', o 'whiledo', o 'elsif', o 'else'";
                    break;
                case 1012:
                    tx.Text = "Error " + e + ": se esperaba ;";
                    break;
                case 1013:
                    tx.Text = "Error " + e + ": se esperaba identificador o palabra reservada 'if', o' 'while' o 'do', o 'read' o 'write'\r\n"
                        + "o 'end', o 'endif', o 'endloop', o 'whiledo', o 'elsif', o 'else'";
                    break;
                case 1014:
                    tx.Text = "Error " + e + ": se esperaba identificador";
                    break;
                case 1015:
                    tx.Text = "Error " + e + ": se esperaba identificador";
                    break;
                case 1016:
                    tx.Text = "Error " + e + ": se esperaba [ o = o * o / o % o + o - o == o != o < o <= o > o >= o && o || o\r\n"
                        + "; o , o ] o ) o palabra reservada 'then', o 'loop' o 'enddo' ";
                    break;
                case 1017:
                    tx.Text = "Error " + e + ": se esperaba ! o ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1018:
                    tx.Text = "Error " + e + ": se esperaba , o ]";
                    break;
                case 1019:
                    tx.Text = "Error " + e + ": se esperaba ! o ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1020:
                    tx.Text = "Error " + e + ": se esperaba ! o ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1021:
                    tx.Text = "Error " + e + ": se esperaba || o ; o , o ] o ) o palabra reservada 'then' o 'loop' o 'enddo'";
                    break;
                case 1022:
                    tx.Text = "Error " + e + ": se esperaba ! o ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1023:
                    tx.Text = "Error " + e + ": se esperaba && o|| o ; o , o ] o ) o palabra reservada 'then' o 'loop' o 'enddo'";
                    break;
                case 1024:
                    tx.Text = "Error " + e + ": se esperaba ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1025:
                    tx.Text = "Error " + e + ": se esperaba ! o ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1026:
                    tx.Text = "Error " + e + ": se esperaba ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1027:
                    tx.Text = "Error " + e + ": se esperaba == o != o < o <= o> o >= o && o || o ; o , o ] o ) \r\n "
                      + "palabra reservada 'then' o 'loop' o 'enddo'";
                    break;
                case 1028:
                    tx.Text = "Error " + e + ": se esperaba + o - o == o != o < o <= o > o >= o && o || o ; o , o ]\r\n"
                   + "o ) o palabra reservada 'then' o 'loop' o 'enddo'";
                    break;
                case 1029:
                    tx.Text = "Error " + e + ": se esperaba == o != o < o <= o > o >=";
                    break;
                case 1030:
                    tx.Text = "Error " + e + ": se esperaba ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1031:
                    tx.Text = "Error " + e + ": se esperaba * o + o - o / o % o == o != o < o <= o > o >= o && o || o ; o , o ] o )\r\n" +
                        "o palabra reservada 'then' o 'loop' o 'enddo' ";
                    break;
                case 1032:
                    tx.Text = "Error " + e + ": se esperaba ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1033:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'if'";
                    break;
                case 1034:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'elsif' o 'else' o 'endif'";
                    break;
                case 1035:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'else' o 'endif'";
                    break;
                case 1036:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'while'";
                    break;
                case 1037:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'do'";
                    break;
                case 1038:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'read'";
                    break;
                case 1039:
                    tx.Text = "Error " + e + ": se esperaba identificador";
                    break;
                case 1040:
                    tx.Text = "Error " + e + ": se esperaba , o )";
                    break;
                case 1041:
                    tx.Text = "Error " + e + ": se esperaba palabra reservada 'write'";
                    break;
                case 1042:
                    tx.Text = "Error " + e + ": se esperaba ! o ( o identificador o constante entera o constante real o\r\n"
                        + "constante en notación científica o constante caracter o constante string";
                    break;
                case 1043:
                    tx.Text = "Error " + e + ": se esperaba , o )'";
                    break;
            }
        }
        #region semantico
        public void acciones(int accion)
        {
            switch (accion-10000)
            {
                case 0:
                    //Console.WriteLine("HOLA");
                    ag_simbolos(var);
                    break;
                case 1:
                    ag_t_simbolos(clave);
                    break;
                case 2:
                    tabla_simbolos.Where(o => o.var == ' ').ToList().ForEach(o => o.var = 'v');
                    break;
                case 3:
                    tabla_simbolos.Where(o => o.var == ' ').ToList().ForEach(o => o.var = 'c');
                    break;
                case 4:
                    ag_consta(edo, 10);
                    break;
            

            }
        }

        public void push_operadores(int op)
        {
            operadores.Push(op);
        }
        public void push_operandos(int ope)
        {
            operandos.Push(ope);
        }
        public void push_tipos(int t)
        {
            tipos.Push(t);
        }

        //inicio dir 
        int dr=10000,dir=20000;
        public void ag_simbolos(string desc)
        {
            
           
            //existe = tabla_simbolos.Where(p => descripcion == desc);
            //busca en la lista para ver si ya existe esa variable
            var existe = tabla_simbolos.FirstOrDefault(p => p.descripcion == desc);
            if (existe != null)
            {
                //si existe despliega un mensaje faltan acciones
                MessageBox.Show("La variable ya existe");
            }else
            {
                //si no existe agrega un nuevo objeto a la lista con la direccion consecutiva
                //la descripcion recibida y con tipo y ram en 0 para indicar que no tienen un valor definida para esas propiedades
                tabla_simbolos.Add(new TabSimbol(dr,desc,0,0,' '));
                MessageBox.Show("Variable agregada correctamente");
                dr++;
            }
            
        }
        public void ag_t_simbolos(int tip)
        {
            //selecciona todos los objetos cuya propiedad tipo sea igual a 0 y les asigna el tipo
            tabla_simbolos.Where(o => o.tipo == 0).ToList().ForEach(o => o.tipo = tip);
        }

        public void ag_consta(int tipo,object val)
        {
            //si el tipo es una constante
            if (tipo >= 102 && tipo <= 106)
            {      
                //si el tipo es constante entera o constante real
           if (tipo == 102 || tipo ==103)
                {
                    //si el tipo de constante concuerda con el tipo de variable constante
                    if ((tipo + 34) == tabla_simbolos.Last().tipo && tabla_simbolos.Last().var == 'c')
                    {
                        //agrega la constante en la tabla de constantes
                        tabla_constantes.Add(new TabConst(dir, tipo, val));
                        dir++;
                        genera_cuadruplo(112, dir - 1, 0, tabla_simbolos.Last().direccion);
                    }
                    else
                    {
                        MessageBox.Show("Tipo: " + tipo);
                        MessageBox.Show("Error de tipos en tabla de constantes");
                        
                    }
                }
                 if (tipo == 105 || tipo == 106 || tipo ==104)
                {
                    if ((tipo + 33) == tabla_simbolos.Last().tipo && tabla_simbolos.Last().var == 'c')
                    {
                        tabla_constantes.Add(new TabConst(dir, tipo, val));
                        dir++;
                        genera_cuadruplo(112, dir - 1, 0,tabla_simbolos.Last().direccion);
                    }
                    else
                    {
                        MessageBox.Show("Tipo: " + tipo);
                        MessageBox.Show("Error de tipos en tabla de constantes");
                       
                    }
                }
               
            }
            
            else
            {
       
                MessageBox.Show("Tipo: " + tipo);
                MessageBox.Show("Error de tipos en tabla de constantes");
             
            }
        }

        public void genera_cuadruplo(int c,int o1,int o2,int r)
        {
            cuadruplos.Add(new Cuadruplo(c, o1, o2, r));
        }
        #endregion semantico
    }

   

    public class TabSimbol 
    {
       public int direccion { get; set; }
        public string descripcion { get; set; }
        public int tipo { get; set; }
        public object ram { get; set; }
        public char var { get; set; }
        
        public TabSimbol(int d,string desc,int tipo, object r,char var)
        {
            this.direccion = d;
            this.descripcion = desc;
            this.tipo = tipo;
            this.ram = r;
            this.var = var;          
        }
    }

    
    public class TabConst
    {
      public  int dir;
        public int tipo;
        public object valor;

        public TabConst(int d,int t,object v)
        {
            this.dir = d;
            this.tipo = t;
            this.valor = v;
        }
        

        }
    }
    class Cuadruplo
    {
        public int codop;
        public int op1;
        public int op2;
        public int res;

    public Cuadruplo(int cod,int o1,int o2,int r)
    {
        this.codop = cod;
        this.op1 = o1;
        this.op2 = o2;
        this.res = r;
    }
    }


