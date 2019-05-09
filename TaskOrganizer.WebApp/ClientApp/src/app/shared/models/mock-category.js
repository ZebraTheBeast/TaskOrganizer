"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CATEGORIES = [
    {
        id: 1, description: 'Category description 1', title: 'Category1', mainObjectives: [
            {
                id: 1, title: 'Main objective 1', description: 'Main objective description 1', status: 'status1', deadLine: new Date("2019-05-16"), childObjectives: [
                    { id: 1, title: 'Child objective 1.1', status: 'status1', deadLine: new Date("2019-05-16") },
                    { id: 2, title: 'Child objective 1.2', status: 'status1', deadLine: new Date("2019-05-16") },
                    { id: 3, title: 'Child objective 1.3', status: 'status1', deadLine: new Date("2019-05-16") }
                ]
            },
            {
                id: 2, title: 'Main objective 2', status: 'status1', childObjectives: [
                    { id: 4, title: 'Child objective 2.1', status: 'status1', deadLine: new Date("2019-05-16") },
                    { id: 5, title: 'Child objective 2.2', status: 'status1', deadLine: new Date("2019-05-16") },
                    { id: 6, title: 'Child objective 2.3', status: 'status1', deadLine: new Date("2019-05-16") }
                ]
            }
        ]
    }
];
//# sourceMappingURL=mock-category.js.map