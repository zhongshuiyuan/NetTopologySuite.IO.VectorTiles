using System.Collections.Generic;
using GeoAPI.Geometries;
using NetTopologySuite.IO.VectorTiles.Tilers;
using NetTopologySuite.IO.VectorTiles.Tiles;
using Xunit;
using Xunit.Abstractions;

namespace NetTopologySuite.IO.VectorTiles.Tests.Tilers
{
    public class PolygonTilerTests
    {
        private readonly ITestOutputHelper _output;
        public PolygonTilerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestAurichAtZoom12()
        {
            var p = (IPolygon) new WKTReader().Read(
                @"POLYGON((7.66002273417368 53.542572993953, 7.66173766036759 53.5391581883133, 7.66214163494917 53.5373509789836, 7.66261436546659 53.5363456891095, 7.66258258916752 53.5359043208466, 7.65946163788716 53.5361457486512, 7.65881558902363 53.5361308714676, 7.65810608331794 53.5359860470069, 7.65747761962654 53.5357003268469, 7.65661359397896 53.5353520707904, 7.65578725023568 53.5351617119411, 7.65464708153475 53.5350069368571, 7.65346462749995 53.5347655193895, 7.65403138432821 53.5341606089694, 7.65205031151564 53.5325629404665, 7.65224246394456 53.5317272731287, 7.65263661471445 53.5305403445236, 7.65295703572944 53.5295585441862, 7.65134183452485 53.5279385344239, 7.64990766659184 53.5272489336876, 7.64795651246382 53.5266193031113, 7.64667314657395 53.526859402532, 7.64520558737573 53.5259891161888, 7.64440606918115 53.5255209689606, 7.64975585690317 53.5228569633467, 7.65969726004108 53.5156942812819, 7.66704312056304 53.5103596986421, 7.67807885014628 53.5025102991622, 7.67823484399266 53.5014235244292, 7.67836569901777 53.4973584713123, 7.6785112111824 53.4947445744109, 7.67865686601526 53.4921278107042, 7.67882449969189 53.4859113935922, 7.67924709466502 53.4785004861189, 7.67919836330843 53.4748108019542, 7.67723423026605 53.4629399238196, 7.67649101699345 53.4616098901849, 7.66580355542624 53.4614273395257, 7.66311090844057 53.4613808081545, 7.66110716581642 53.4613461439011, 7.64579099018915 53.4614327788683, 7.64004762841675 53.4614614087227, 7.63938439867634 53.4614639907499, 7.63313979051077 53.4615526008196, 7.63231045753101 53.4615602711485, 7.61289759957413 53.4618351425737, 7.61173604786319 53.4618528723687, 7.60762855138664 53.4619813035104, 7.60621890196816 53.4618762390592, 7.60518838805592 53.461735103933, 7.60420954210398 53.4614962467803, 7.59709165946356 53.4595209647634, 7.59285423909206 53.4570646862747, 7.57378790429858 53.4512618088765, 7.57488498202143 53.449947817854, 7.573841603558 53.4497791232224, 7.57290472664486 53.4495949643638, 7.57212666860197 53.4492886632551, 7.57074983508698 53.4484734553263, 7.56989595524777 53.4479494848721, 7.56920639668005 53.447672251375, 7.56794347392134 53.4474083399895, 7.56771785312692 53.4474029659531, 7.56666495681686 53.4473778816517, 7.56558921269671 53.4474691627534, 7.56466868448323 53.4474921854867, 7.56403694631481 53.4474771203478, 7.56324756744044 53.4473413721552, 7.56219707105994 53.4470554868482, 7.56152081204126 53.446805507402, 7.56082951968706 53.4465551650648, 7.55973270444055 53.4480849002096, 7.5574049262738 53.4473007819125, 7.55837667104114 53.4456151812924, 7.55756930595791 53.4452990888793, 7.55577894695629 53.4445907356897, 7.55451263695829 53.4439308712552, 7.55177198999928 53.4425701414111, 7.54898343453635 53.4410283181794, 7.54753149191263 53.4402200214219, 7.54721212005 53.4400414754077, 7.54611383780716 53.4395744193849, 7.54477790895202 53.4392815256986, 7.54319654466954 53.4390546725156, 7.54129757757432 53.4388471458545, 7.53991234856266 53.4386159705052, 7.53902763140178 53.4383338638073, 7.53824819118433 53.4380542839215, 7.53801728179469 53.4379048231959, 7.53909063180858 53.4349446459896, 7.53343220433349 53.4295288676704, 7.53374100509811 53.4280792718612, 7.53119153708028 53.4292589693867, 7.53021731938459 53.4283000746834, 7.52720599047241 53.4285151688701, 7.52152104777082 53.4299167621297, 7.51902247266398 53.4285712171545, 7.51816670390709 53.428264916467, 7.51710559833197 53.4280488205837, 7.51614876750708 53.4279057493073, 7.51546329651903 53.4277991827445, 7.51379977700565 53.4274450968318, 7.51329074876308 53.4273137558868, 7.51242599231396 53.4265550488522, 7.51169940276447 53.426016918458, 7.51039710422691 53.4253397030691, 7.50964690623155 53.4246551492491, 7.50922140445748 53.4238832928566, 7.50937310012044 53.4234110350202, 7.50927967672727 53.4230280063694, 7.50836396773255 53.422434607247, 7.50792231517904 53.421900325649, 7.50748715160113 53.4212710099059, 7.50633611510549 53.4206242737467, 7.50559017975338 53.4204633345195, 7.50497815237943 53.4200914743434, 7.50419312326653 53.4181685637444, 7.50383434495481 53.4175886853887, 7.50309735725173 53.4167140221241, 7.50207927873115 53.4159693748739, 7.500804291032 53.415390950291, 7.4987802786469 53.414699047165, 7.49440619676722 53.4134261585501, 7.49249841282811 53.4127845820726, 7.49056231874291 53.4119756977621, 7.48867583552404 53.4110252077525, 7.48474999142798 53.4084540434014, 7.4831056036462 53.4074617975491, 7.48034097948121 53.4059660655654, 7.4790300804891 53.4053389181442, 7.47892058613044 53.40714657593, 7.47741935656623 53.4086715714717, 7.48029976279993 53.4109913652061, 7.48416161874033 53.4130226760823, 7.4829014820479 53.4133965222814, 7.48590955761809 53.4149723406003, 7.48702863309396 53.4155574107977, 7.48380783133966 53.4166387574233, 7.47550361659277 53.4163269233001, 7.47459820535725 53.4172310877098, 7.4684052567252 53.4181759457442, 7.47304826559368 53.4235520295864, 7.46923111591881 53.4240966597234, 7.47425911682967 53.4297969374408, 7.47638598797997 53.4299661455246, 7.47682775435839 53.4329541261597, 7.47456383786266 53.4338968580183, 7.47255120806518 53.4318506150376, 7.45967363132316 53.430336855972, 7.46171379396834 53.4358918220705, 7.46019396755926 53.4360881443513, 7.45938996642748 53.4344313019637, 7.4495433433577 53.4343764965982, 7.42684641320768 53.4528531296473, 7.42440386744693 53.4530889503513, 7.42262509482772 53.4513805267689, 7.41991068800476 53.4514115827459, 7.41791554859279 53.4519283013927, 7.41681224895592 53.4524043658418, 7.4177147903743 53.4537131750182, 7.41689104320728 53.4540703165688, 7.41496550375083 53.454237948612, 7.41282683868576 53.4555065279233, 7.41247706700052 53.457692407403, 7.41419559581998 53.4581132564512, 7.4119592342897 53.4609803841439, 7.41059901951635 53.4608203422716, 7.40704764009092 53.4645898066924, 7.40209859193935 53.4677581564188, 7.40261279012765 53.4678186856304, 7.40354524056939 53.4676041554426, 7.40440369794126 53.4679578070499, 7.40579565493035 53.4684936390418, 7.4078479884247 53.469484876137, 7.41103505867176 53.4693939589474, 7.41931574822656 53.4738286953717, 7.41982679673488 53.4768545609361, 7.4199663086204 53.4776585391313, 7.41874689838154 53.4797776721282, 7.41494551547179 53.4838738562383, 7.4138613709614 53.4844942893328, 7.40966503329603 53.4869074942498, 7.40582224824959 53.4915690059714, 7.41118229359556 53.496191576212, 7.41309813277124 53.5008985402984, 7.41248681534515 53.5022953035192, 7.41461977980361 53.5030682423759, 7.41613588399826 53.5036640020981, 7.42031572033468 53.5053063041034, 7.43898222446275 53.5124537351449, 7.44160148483052 53.5135441720523, 7.4419288149163 53.5157177540155, 7.44338320004665 53.5263430986413, 7.44222382245717 53.5269330553169, 7.43639090590775 53.5295675911135, 7.42923837226542 53.5327623889009, 7.43371690130246 53.5356348811498, 7.43789396339659 53.5369977599669, 7.43600306944031 53.5392082260362, 7.44166521206808 53.5411474558971, 7.44585285056978 53.5376087727529, 7.44774102224654 53.5360122050406, 7.44864235638966 53.5352764999947, 7.46187716698679 53.5400970667175, 7.46752469468945 53.5421872368783, 7.46949216758275 53.5428863718375, 7.47421839434015 53.5446301869531, 7.47579471401796 53.54519944686, 7.47608937514685 53.5453055965896, 7.47817187873059 53.5457613210688, 7.47868193018024 53.5458097852917, 7.48211726969819 53.5461366792699, 7.48184638745224 53.5472182543925, 7.48213157348277 53.5472432165523, 7.49518709828013 53.5484341862577, 7.5097227860447 53.5498986183235, 7.52373027597351 53.551275303097, 7.53185628909422 53.5521340909921, 7.55358235319526 53.553790254814, 7.56455371077402 53.5548071068002, 7.57406901922724 53.555923353685, 7.59471587695231 53.5581810708313, 7.59854383022084 53.5587502150964, 7.61873347139971 53.5611947422757, 7.62266476099469 53.5617239928013, 7.63264843632057 53.5617107926166, 7.64793910227671 53.5616450951347, 7.6492258209762 53.5613690742985, 7.6504454266148 53.560731792846, 7.65610572328535 53.5505918455274, 7.66002273417368 53.542572993953))");

            var lst = new List<IGeometry>();
            var lst2 = new List<IGeometry>();
            var lst3 = new List<IGeometry>();
            foreach (var valueTuple in PolygonTiler.Tiles(p, 12))
            {
                var geom = (IGeometry) valueTuple.Item2;
                for (var i = 0; i < geom.NumGeometries; i ++)
                    lst.Add(geom.GetGeometryN(i));

                var tile = new Tile(valueTuple.Item1);
                lst2.Add(tile.ToPolygon(0));
                lst3.Add(tile.ToPolygon(5));
                _output.WriteLine("Tile id {0}: Tile {1} / Geometry: {2}", valueTuple.Item1, tile, tile.ToPolygon());
            }

            _output.WriteLine("\n");
            _output.WriteLine("\n\nResult1:\n{0}", p.Factory.BuildGeometry(lst));
            _output.WriteLine("\n\nResult2:\n{0}", p.Factory.BuildGeometry(lst2));
            _output.WriteLine("\n\nResult3:\n{0}", p.Factory.BuildGeometry(lst3));
        }
    }
}