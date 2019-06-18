$(function () {
    testeTree();


    function testeTree() {

        var data = [
            {
                name: 'node1',
                children: [
                    { name: 'child1' },
                    { name: 'child2' }
                ]
            },
            {
                name: 'node2',
                children: [
                    { name: 'child3' }
                ]
            }
        ];

        $('#tree1').tree({
            data:data
        });
    }

});